using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.FlightSimulator.SimConnect;
using Serilog;

namespace CTrue.FsConnect
{
    /// <inheritdoc />
    public class FsConnect : IFsConnect
    {
        
        private SimConnect _simConnect = null;

        private EventWaitHandle _simConnectEventHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        private Thread _simConnectReceiveThread = null;
        private readonly FsConnectionInfo _connectionInfo = new FsConnectionInfo();
        private bool _paused = false;

        #region Simconnect structures

        private enum SimEvents
        {
            EVENT_AIRCRAFT_LOAD,
            EVENT_FLIGHT_LOAD,
            EVENT_PAUSED,
            EVENT_PAUSE,
            EVENT_SIM,
            EVENT_CRASHED,
            ObjectAdded,
            PauseSet,
            SetText
        }

        enum GROUP_IDS
        {
            GROUP_1 = 98,
        }

        #endregion

        /// <inheritdoc />
        public event EventHandler ConnectionChanged;

        /// <inheritdoc />
        public event EventHandler<FsDataReceivedEventArgs> FsDataReceived;

        /// <inheritdoc />
        public event EventHandler<ObjectAddRemoveEventReceivedEventArgs> ObjectAddRemoveEventReceived;

        /// <inheritdoc />
        public event EventHandler<FsErrorEventArgs> FsError;

        /// <inheritdoc />
        public event EventHandler AircraftLoaded;

        /// <inheritdoc />
        public event EventHandler FlightLoaded;

        /// <inheritdoc />
        public event EventHandler<PauseStateChangedEventArgs> PauseStateChanged;

        /// <inheritdoc />
        public event EventHandler<SimStateChangedEventArgs> SimStateChanged;

        /// <inheritdoc />
        public event EventHandler Crashed;

        /// <inheritdoc />
        public bool Connected
        {
            get => _connectionInfo.Connected;
            private set
            {
                if (_connectionInfo.Connected != value)
                {
                    _connectionInfo.Connected = value;
                    
                    ConnectionChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public FsConnectionInfo ConnectionInfo => _connectionInfo;

        /// <inheritdoc />
        public SimConnectFileLocation SimConnectFileLocation { get; set; } = SimConnectFileLocation.Local;

        /// <inheritdoc />
        public bool Paused => _paused;

        /// <inheritdoc />
        public void Connect(string applicationName, uint configIndex = 0)
        {
            try
            {
                _simConnect = new SimConnect(applicationName, IntPtr.Zero, 0, _simConnectEventHandle, configIndex);
            }
            catch (Exception e)
            {
                _simConnect = null;
                throw new Exception("Could not connect to Flight Simulator: " + e.Message, e);
            }

            _simConnectReceiveThread = new Thread(new ThreadStart(SimConnect_MessageReceiveThreadHandler));
            _simConnectReceiveThread.IsBackground = true;
            _simConnectReceiveThread.Start();

            _simConnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(SimConnect_OnRecvOpen);
            _simConnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(SimConnect_OnRecvQuit);

            _simConnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(SimConnect_OnRecvException);
            _simConnect.OnRecvSimobjectData += new SimConnect.RecvSimobjectDataEventHandler(SimConnect_RecvSimObjectData);
            _simConnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(SimConnect_OnRecvSimobjectDataBytype);
            _simConnect.OnRecvEventObjectAddremove += new SimConnect.RecvEventObjectAddremoveEventHandler(SimConnect_OnRecvEventObjectAddremoveEventHandler);

            _simConnect.OnRecvEvent += SimConnect_OnRecvEvent;

            // System events
            _simConnect.SubscribeToSystemEvent(SimEvents.EVENT_AIRCRAFT_LOAD, "AircraftLoaded");
            _simConnect.SubscribeToSystemEvent(SimEvents.EVENT_FLIGHT_LOAD, "FlightLoaded");
            _simConnect.SubscribeToSystemEvent(SimEvents.EVENT_PAUSED, "Paused");
            _simConnect.SubscribeToSystemEvent(SimEvents.EVENT_PAUSE, "Pause");
            _simConnect.SubscribeToSystemEvent(SimEvents.EVENT_SIM, "Sim");
            _simConnect.SubscribeToSystemEvent(SimEvents.EVENT_CRASHED, "Crashed");
            _simConnect.SubscribeToSystemEvent(SimEvents.ObjectAdded, "ObjectAdded");

            // Client events
            _simConnect.MapClientEventToSimEvent(SimEvents.PauseSet, "PAUSE_SET");
        }

        /// <inheritdoc />
        public void Connect(string applicationName, string hostName, uint port, SimConnectProtocol protocol)
        {
            if (applicationName == null) throw new ArgumentNullException(nameof(applicationName));

            CreateSimConnectConfigFile(hostName, port, protocol);

            Connect(applicationName);
        }

        /// <inheritdoc />
        public void Disconnect()
        {
            if (!Connected) return;

            try
            {
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.EVENT_AIRCRAFT_LOAD);
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.EVENT_FLIGHT_LOAD);
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.EVENT_PAUSED);
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.EVENT_PAUSE);
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.EVENT_SIM);
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.EVENT_CRASHED);
                _simConnect.UnsubscribeFromSystemEvent(SimEvents.ObjectAdded);

                _simConnect.RemoveClientEvent(GROUP_IDS.GROUP_1, SimEvents.PauseSet);
                _simConnectReceiveThread.Abort();
                _simConnectReceiveThread.Join();

                _simConnect.OnRecvOpen -= new SimConnect.RecvOpenEventHandler(SimConnect_OnRecvOpen);
                _simConnect.OnRecvQuit -= new SimConnect.RecvQuitEventHandler(SimConnect_OnRecvQuit);
                _simConnect.OnRecvException -= new SimConnect.RecvExceptionEventHandler(SimConnect_OnRecvException);
                _simConnect.OnRecvSimobjectData -= new SimConnect.RecvSimobjectDataEventHandler(SimConnect_RecvSimObjectData);
                _simConnect.OnRecvSimobjectDataBytype -= new SimConnect.RecvSimobjectDataBytypeEventHandler(SimConnect_OnRecvSimobjectDataBytype);
                _simConnect.OnRecvEvent -= SimConnect_OnRecvEvent;

                _simConnect.Dispose();
            }
            catch (Exception e)
            {
            }
            finally
            {
                _simConnectReceiveThread = null;
                _simConnect = null;

                _connectionInfo.ApplicationName = "";
                _connectionInfo.ApplicationVersionMajor = 0;
                _connectionInfo.ApplicationVersionMinor = 0;
                _connectionInfo.ApplicationBuildMajor = 0;
                _connectionInfo.ApplicationBuildMinor = 0;
                _connectionInfo.SimConnectBuildMajor = 0;
                _connectionInfo.SimConnectBuildMinor = 0;

                Connected = false;
            }
        }

        /// <inheritdoc />
        public void RegisterDataDefinition<T>(Enum id, List<SimProperty> definition) where T : struct
        {
            foreach (var item in definition)
            {
                _simConnect.AddToDataDefinition(id, item.Name, item.Unit, item.DataType, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            }

            _simConnect.RegisterDataDefineStruct<T>(id);
        }

        /// <inheritdoc />
        public void RequestDataOnSimObject(Enum requestId, Enum defineId, uint objectId, SIMCONNECT_PERIOD period, SIMCONNECT_DATA_REQUEST_FLAG flags, uint interval, uint origin, uint limit)
        {
            _simConnect?.RequestDataOnSimObject(requestId, defineId, objectId, period, flags, interval, origin, limit);
        }

        /// <inheritdoc />
        public void RequestData(Enum requestId, Enum defineId, uint radius = 0, SIMCONNECT_SIMOBJECT_TYPE type = SIMCONNECT_SIMOBJECT_TYPE.USER)
        {
            _simConnect?.RequestDataOnSimObjectType( requestId, defineId, radius, type);
        }

        /// <inheritdoc />
        public void UpdateData<T>(Enum id, T data, uint objectId = 1)
        {
            _simConnect?.SetDataOnSimObject(id, objectId, SIMCONNECT_DATA_SET_FLAG.DEFAULT, data);
        }

        /// <inheritdoc />
        public void SetText(string text, int duration)
        {
            _simConnect.Text(SIMCONNECT_TEXT_TYPE.PRINT_BLACK, duration, SimEvents.SetText, text);
        }

        /// <inheritdoc />
        public void Pause()
        {
            Pause(!_paused);
        }

        /// <inheritdoc />
        public void Pause(bool pause)
        {
            _simConnect.TransmitClientEvent(0, SimEvents.PauseSet, pause ? (uint)1 : (uint)0, GROUP_IDS.GROUP_1, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            _paused = true;
        }

        #region Event Handlers

        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Log.Debug("OnRecvOpen (Size: {Size}, Version: {Version}, Id: {Id})", data.dwSize, data.dwVersion, data.dwID);

            _connectionInfo.ApplicationName = data.szApplicationName;
            _connectionInfo.ApplicationVersionMajor = data.dwApplicationVersionMajor;
            _connectionInfo.ApplicationVersionMinor = data.dwApplicationVersionMinor;
            _connectionInfo.ApplicationBuildMajor = data.dwApplicationBuildMajor;
            _connectionInfo.ApplicationBuildMinor = data.dwApplicationBuildMinor;
            _connectionInfo.SimConnectVersionMajor = data.dwSimConnectVersionMajor;
            _connectionInfo.SimConnectVersionMinor = data.dwSimConnectVersionMinor;
            _connectionInfo.SimConnectBuildMajor = data.dwSimConnectBuildMajor;
            _connectionInfo.SimConnectBuildMinor = data.dwSimConnectBuildMinor;

            Connected = true;
        }

        private void SimConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            Log.Debug("OnRecvQuit (S: {Size}, V: {Version}, I: {Id})", data.dwSize, data.dwVersion, data.dwID);
            Disconnect();
        }

        private void SimConnect_OnRecvEvent(SimConnect sender, SIMCONNECT_RECV_EVENT data)
        {
            Log.Debug("OnRecvEvent (S: {Size}, V: {Version}, I: {Id}) {GroupId}, {EventId}, {Data}", data.dwSize, data.dwVersion, data.dwID, data.uGroupID, data.uEventID, data.dwData);

            if (data.uEventID == (uint)SimEvents.EVENT_AIRCRAFT_LOAD)
            {
                Log.Debug("SysEvent: Aircraft loaded");
                AircraftLoaded?.Invoke(this, EventArgs.Empty);
            }
            else if (data.uEventID == (uint)SimEvents.EVENT_FLIGHT_LOAD)
            {
                Log.Debug("SysEvent: Flight loaded");
                FlightLoaded?.Invoke(this, EventArgs.Empty);
            }
            else if (data.uEventID == (uint)SimEvents.EVENT_SIM)
            {
                Log.Debug("SysEvent: Running: {Running}", data.dwData == 1);
                SimStateChanged?.Invoke(this, new SimStateChangedEventArgs() { Running = data.dwData == 1 });
            }
            else if (data.uEventID == (uint)SimEvents.EVENT_CRASHED)
            {
                Log.Debug("SysEvent: Crashed");
                Crashed?.Invoke(this, EventArgs.Empty);
            }
            else if (data.uEventID == (uint)SimEvents.EVENT_PAUSE)
            {
                _paused = data.dwData == 1;
                Log.Debug("ClientEvent: Paused: {Paused}", _paused);
                PauseStateChanged?.Invoke(this, new PauseStateChangedEventArgs() { Paused = data.dwData == 1 });
            }
        }

        private void SimConnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            Log.Warning("OnRecvException ({Size}b/{Version}/{Id}) Exception: {Exception}, SendId: {SendId}, Index: {Index}", data.dwSize, data.dwVersion, data.dwID, ((FsException)data.dwException).ToString(), data.dwSendID, data.dwIndex);

            SIMCONNECT_EXCEPTION eException = (SIMCONNECT_EXCEPTION)data.dwException;

            FsError?.Invoke(this, new FsErrorEventArgs()
            {
                ExceptionCode = (FsException)data.dwException,
                ExceptionDescription = ((FsException)data.dwException).ToString(),
                SendID = data.dwSendID,
                Index = data.dwIndex
            });
        }

        private void SimConnect_RecvSimObjectData(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            Log.Debug("RecvSimObjectData (S: {Size}, V: {Version}, I: {Id}) RequestID: {RequestID}, ObjectID: {ObjectID}, DefineID: {DefineID}, Flags: {Flags},EntryNumber: {EntryNumber}, OutOf: {OutOf}, DefineCount: {DefineCount}, DataItems: {DataItems}", data.dwSize, data.dwVersion, data.dwID, data.dwRequestID, data.dwObjectID, data.dwDefineID, data.dwFlags, data.dwentrynumber, data.dwoutof, data.dwDefineCount, data.dwData.Length);

            FsDataReceived?.Invoke(this, new FsDataReceivedEventArgs()
            {
                RequestId = data.dwRequestID,
                Data = data.dwData[0],
                ObjectID = data.dwObjectID
            });
        }

        private void SimConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            Log.Debug("RecvSimObjectData (S: {Size}, V: {Version}, I: {Id}) RequestID: {RequestID}, ObjectID: {ObjectID}, DefineID: {DefineID}, Flags: {Flags},EntryNumber: {EntryNumber}, OutOf: {OutOf}, DefineCount: {DefineCount}, DataItems: {DataItems}", data.dwSize, data.dwVersion, data.dwID, data.dwRequestID, data.dwObjectID, data.dwDefineID, data.dwFlags, data.dwentrynumber, data.dwoutof, data.dwDefineCount, data.dwData.Length);

            FsDataReceived?.Invoke(this, new FsDataReceivedEventArgs()
            {
                RequestId = data.dwRequestID,
                Data = data.dwData[0],
                ObjectID = data.dwObjectID
            });
        }

        private void SimConnect_OnRecvEventObjectAddremoveEventHandler(SimConnect sender, SIMCONNECT_RECV_EVENT data)
        {
            Log.Debug("OnRecvEventObjectAddremoveEventHandler ({Size}b/{Version}/{Id}) EventId: {EventId}, Data: {Data}, Id: {Id}", data.dwSize, data.dwVersion, data.dwID, data.uEventID, data.dwData, data.dwID);

            ObjectAddRemoveEventReceived?.Invoke(this, new ObjectAddRemoveEventReceivedEventArgs()
            {
                RequestId = data.uEventID,
                Data = data.dwData,
                ObjectID = data.dwID
            });
        }

        #endregion

        private void SimConnect_MessageReceiveThreadHandler()
        {
            while (true)
            {
                _simConnectEventHandle.WaitOne();

                try
                {
                    _simConnect?.ReceiveMessage();
                }
                catch (Exception e)
                {
                }
            }
        }

        private void CreateSimConnectConfigFile(string hostName, uint port, SimConnectProtocol protocol)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                string protocolString = "Ipv4";

                switch (protocol)
                {
                    case SimConnectProtocol.Pipe:
                        protocolString = "Pipe";
                        break;
                    case SimConnectProtocol.Ipv4:
                        protocolString = "Ipv4";
                        break;
                    case SimConnectProtocol.Ipv6:
                        protocolString = "Ipv6";
                        break;
                }

                sb.AppendLine("[SimConnect]");
                sb.AppendLine("Protocol=" + protocolString);
                sb.AppendLine($"Address={hostName}");
                sb.AppendLine($"Port={port}");

                string directory = "";
                if (SimConnectFileLocation == SimConnectFileLocation.Local)
                    directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                else
                    directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                string fileName = Path.Combine(directory, "SimConnect.cfg");

                File.WriteAllText(fileName, sb.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Could not create SimConnect.cfg file: " + e.Message, e);
            }
        }

        // To detect redundant calls
        private bool _disposed = false;

        /// <summary>
        /// Disconnects and disposes the client.
        /// </summary>
        public void Dispose() => Dispose(true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _simConnect?.Dispose();
            }

            _disposed = true;
        }

    }
}
