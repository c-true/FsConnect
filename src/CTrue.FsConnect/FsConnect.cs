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

        public enum DEFINITIONS
        {
            Struct1,
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
        public SimConnectFileLocation SimConnectFileLocation { get; set; } = SimConnectFileLocation.MyDocuments;

        /// <inheritdoc />
        public event EventHandler ConnectionChanged;

        /// <inheritdoc />
        public event EventHandler<FsDataReceivedEventArgs> FsDataReceived;

        /// <inheritdoc />
        public event EventHandler<FsErrorEventArgs> FsError;

        /// <inheritdoc />
        public void Connect(string applicationName)
        {
            try
            {
                _simConnect = new SimConnect(applicationName, IntPtr.Zero, 0, _simConnectEventHandle, 0);
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
                _simConnectReceiveThread.Abort();
                _simConnectReceiveThread.Join();

                _simConnect.OnRecvOpen -= new SimConnect.RecvOpenEventHandler(SimConnect_OnRecvOpen);
                _simConnect.OnRecvQuit -= new SimConnect.RecvQuitEventHandler(SimConnect_OnRecvQuit);
                _simConnect.OnRecvException -= new SimConnect.RecvExceptionEventHandler(SimConnect_OnRecvException);
                _simConnect.OnRecvSimobjectDataBytype -= new SimConnect.RecvSimobjectDataBytypeEventHandler(SimConnect_OnRecvSimobjectDataBytype);
                
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

        /// <inheritdoc />
        public void RequestData(Enum requestId)
        {
            _simConnect?.RequestDataOnSimObjectType( requestId, DEFINITIONS.Struct1, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
        }

        /// <inheritdoc />
        public void UpdateData<T>(Enum id, T data)
        {
            _simConnect?.SetDataOnSimObject(id, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_DATA_SET_FLAG.DEFAULT, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="duration"></param>
        public void SetText(string text, int duration)
        {
            _simConnect.Text(SIMCONNECT_TEXT_TYPE.PRINT_BLACK, duration, DEFINITIONS.Struct1, text);
        }

        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Connected = true;
        }

        private void SimConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            Disconnect();
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
                Data = data.dwData[0]
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
