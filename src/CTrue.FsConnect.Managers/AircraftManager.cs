﻿using System;
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

    public class AircraftInfoUpdatedEventArgs<T> : EventArgs
    {
        public T AircraftInfo { get; set; }
    }

    /// <summary>
    /// The <see cref="AircraftManager{T}"/> is a simple way to request information about the user aircraft.
    /// </summary>
    /// <typeparam name="T">The type that represents the aircraft information that will be requested.</typeparam>
    /// <remarks>
    /// The type used to represent aircraft information must already be registered with SimConnect using <see cref="FsConnect"/>.
    /// <see cref="FsConnect"/> must already be connected before using this manager.
    /// </remarks>
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

        public EventHandler<AircraftInfoUpdatedEventArgs<T>> Updated;

        /// <summary>
        /// Gets or sets whether to poll the flight simulator manually, using the <see cref="Get"/> method, or getting automatic updates using the <see cref="Updated"/> event.
        /// </summary>
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

        /// <summary>
        /// Creates an instance of the <see cref="AircraftManager{T}"/> class.
        /// </summary>
        /// <param name="fsConnect"></param>
        /// <param name="defineId">The definition used when registering the aircraft information structure.</param>
        /// <param name="requestId">The request Id to use when requesting data using the manager.</param>
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

                    Updated?.Invoke(this, new AircraftInfoUpdatedEventArgs<T>()
                    {
                        AircraftInfo = _aircraftInfo
                    });
                }
            }
            catch
            {
                // Ignored
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