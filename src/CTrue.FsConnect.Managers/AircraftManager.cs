using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect.Managers
{
    public enum RequestMethod
    {
        Poll,
        Continuously
    }

    public class AircraftManager<T> : IDisposable where T : struct
    {
        private readonly AutoResetEvent _getResetEvent = new AutoResetEvent(false);
        private bool _disposed;

        private readonly IFsConnect _fsConnect;
        private Enum _requestId;
        private uint _requestIdUInt;
        private Enum _aircraftInfoDefinitionId;

        private T _aircraftInfo;
        private RequestMethod _requestMethod = RequestMethod.Poll;

        public RequestMethod RequestMethod
        {
            get => _requestMethod;
            set
            {
                if (value == _requestMethod) return;

                _requestMethod = value;

                if (_requestMethod == RequestMethod.Poll)
                    Stop();
                else
                    Start();
            }
        }


        public AircraftManager(IFsConnect fsConnect, Enum defineId, Enum requestId)
        {
            _fsConnect = fsConnect;

            _fsConnect.FsDataReceived += HandleReceivedFsData;

            _aircraftInfoDefinitionId = defineId;
            _requestId = requestId;
            _requestIdUInt = Convert.ToUInt32(requestId);
        }

        private void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.RequestId == _requestIdUInt)
                {
                    _aircraftInfo = (T)e.Data;
                    _getResetEvent.Set();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not handle received FS data: " + ex);
            }
        }

        public T Get()
        {
            if(RequestMethod == RequestMethod.Poll)
            {
                _fsConnect.RequestData(_requestId, _aircraftInfoDefinitionId);
                bool success = _getResetEvent.WaitOne(1000);

                if (!success)
                    throw new Exception("Could not get aircraft info. Call to flight simulator timed out.");
            }

            return _aircraftInfo;
        }

        public void Start()
        {
            _fsConnect.RequestDataOnSimObject(_requestId, _aircraftInfoDefinitionId, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.SECOND, 0,
                0, 0, 0);
        }

        public void Stop()
        {
            _fsConnect.RequestDataOnSimObject(_requestId, _aircraftInfoDefinitionId, SimConnect.SIMCONNECT_OBJECT_ID_USER, SIMCONNECT_PERIOD.NEVER, 0,
                0, 0, 0);
        }
        
        public void Dispose() => Dispose(true);
        
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_requestMethod == RequestMethod.Continuously)
                    Stop();

                _fsConnect.FsDataReceived -= HandleReceivedFsData;
            }

            _disposed = true;
        }
    }
}