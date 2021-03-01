using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.FlightSimulator.SimConnect;
using System.Diagnostics;

namespace CTrue.FsConnect
{
    /// <inheritdoc />
    public class FsConnect : IFsConnect
    {
        private SimConnect _simConnect = null;

        private EventWaitHandle _simConnectEventHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        private Thread _simConnectReceiveThread = null;
        private bool _connected;

        #region Simconnect structures

        private enum DEFINITIONS
        {
            PlaneInfo,
        }

        private enum SimEvents
        {
            EVENT_AIRCRAFT_LOAD,
            EVENT_FLIGHT_LOAD,
            EVENT_PAUSED,
            EVENT_PAUSE,
            EVENT_SIM,
            EVENT_CRASHED,
            ObjectAdded,
            PauseSet
        }

        enum GROUP_IDS
        {
            GROUP_1 = 98,
        }

        #endregion

        /// <inheritdoc />
        public bool Connected
        {
            get => _connected;
            private set
            {
                if (_connected != value)
                {
                    _connected = value;
                    ConnectionChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <inheritdoc />
        public SimConnectFileLocation SimConnectFileLocation { get; set; } = SimConnectFileLocation.Local;

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

        public void RequestDataOnSimObject(Enum requestId, uint objectId, SIMCONNECT_PERIOD period, SIMCONNECT_DATA_REQUEST_FLAG flags, uint interval, uint origin, uint limit)
        {
            _simConnect?.RequestDataOnSimObject(requestId, DEFINITIONS.PlaneInfo, objectId, period, flags, interval, origin, limit);
        }

        /// <inheritdoc />
        public void RequestData(Enum requestId, uint radius = 0, SIMCONNECT_SIMOBJECT_TYPE type = SIMCONNECT_SIMOBJECT_TYPE.USER)
        {
            _simConnect?.RequestDataOnSimObjectType( requestId, DEFINITIONS.PlaneInfo, radius, type);
        }

        /// <inheritdoc />
        public void UpdateData<T>(Enum id, T data, uint objectId = 1)
        {
            _simConnect?.SetDataOnSimObject(id, objectId, SIMCONNECT_DATA_SET_FLAG.DEFAULT, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="duration"></param>
        public void SetText(string text, int duration)
        {
            _simConnect.Text(SIMCONNECT_TEXT_TYPE.PRINT_BLACK, duration, DEFINITIONS.PlaneInfo, text);
        }

        public void Pause(bool pause)
        {
            _simConnect.TransmitClientEvent(0, SimEvents.PauseSet, pause ? (uint)1 : (uint)0, GROUP_IDS.GROUP_1, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
        }

        #region Event Handlers

        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Connected = true;
        }

        private void SimConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            Disconnect();
        }

        private void SimConnect_OnRecvEvent(SimConnect sender, SIMCONNECT_RECV_EVENT data)
        {
            if (data.uEventID == (uint)SimEvents.EVENT_AIRCRAFT_LOAD)
                AircraftLoaded?.Invoke(this, EventArgs.Empty);
            else if (data.uEventID == (uint)SimEvents.EVENT_FLIGHT_LOAD)
                FlightLoaded?.Invoke(this, EventArgs.Empty);
            else if (data.uEventID == (uint)SimEvents.EVENT_PAUSE)
                PauseStateChanged?.Invoke(this, new PauseStateChangedEventArgs() { Paused = data.dwData == 1 });
            else if (data.uEventID == (uint)SimEvents.EVENT_SIM)
                SimStateChanged?.Invoke(this, new SimStateChangedEventArgs() { Running = data.dwData == 1 });
            else if (data.uEventID == (uint)SimEvents.EVENT_CRASHED)
                Crashed?.Invoke(this, EventArgs.Empty);
        }

        private void SimConnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            SIMCONNECT_EXCEPTION eException = (SIMCONNECT_EXCEPTION)data.dwException;

            FsError?.Invoke(this, new FsErrorEventArgs()
            {
                Exception = data.dwException,
                ExceptionDescription = eException.ToString(),
                SendID = data.dwSendID,
                Index = data.dwIndex
            });
        }

        private void SimConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            FsDataReceived?.Invoke(this, new FsDataReceivedEventArgs()
            {
                RequestId = data.dwRequestID,
                Data = data.dwData[0],
                ObjectID = data.dwObjectID
            });
        }

        private void SimConnect_OnRecvEventObjectAddremoveEventHandler(SimConnect sender, SIMCONNECT_RECV_EVENT recEvent)
        {
            ObjectAddRemoveEventReceived?.Invoke(this, new ObjectAddRemoveEventReceivedEventArgs()
            {
                RequestId = recEvent.uEventID,
                Data = recEvent.dwData,
                ObjectID = recEvent.dwID
            });
        }

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

        #endregion

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
