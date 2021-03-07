using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect.Managers
{
    /// <summary>
    /// The <see cref="SimObjectManager{T}"/> is a simple way to request information about Sim Objects in Microsoft Flight Simulator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISimObjectManager<T> : IDisposable where T : struct
    {
        /// <summary>
        /// Gets or sets the radius, in meters relative to the user position, to get Sim Objects.
        /// </summary>
        uint Radius { get; set; }

        SIMCONNECT_SIMOBJECT_TYPE SimObjectType { get; set; }

        /// <summary>
        /// Gets the current list of known Sim Objects.
        /// </summary>
        /// <returns></returns>
        List<T> Get();

        /// <summary>
        /// Gets the current list of known Sim Objects by waiting for all items before returning.
        /// </summary>
        /// <returns>A list of sim objects.</returns>
        /// <remarks>Note: The current sim objects list is cleared.</remarks>
        List<T> GetWithRequest();

        /// <summary>
        /// Starts an asynchronous request for Sim Objects.
        /// </summary>
        void Request();

        /// <summary>
        /// Clears the list of known Sim Objects.
        /// </summary>
        void Clear();
    }


    /// <inheritdoc />
    public class SimObjectManager<T> : ISimObjectManager<T> where T : struct
    {
        private readonly AutoResetEvent _getResetEvent = new AutoResetEvent(false);
        private bool _disposed;

        private readonly IFsConnect _fsConnect;
        private Enum _requestId;
        private uint _requestIdUInt;
        private Enum _definitionId;

        private Dictionary<uint, T> _simObjects = new Dictionary<uint, T>();

        /// <summary>
        /// Gets or sets the radius, in meters relative to the user position, to get Sim Objects.
        /// </summary>
        public uint Radius { get; set; } = 1000;

        public SIMCONNECT_SIMOBJECT_TYPE SimObjectType { get; set; } = SIMCONNECT_SIMOBJECT_TYPE.ALL;

        public SimObjectManager(IFsConnect fsConnect, Enum defineId, Enum requestId)
        {
            _fsConnect = fsConnect;

            _fsConnect.FsDataReceived += HandleReceivedFsData;

            _definitionId = defineId;
            _requestId = requestId;
            _requestIdUInt = Convert.ToUInt32(requestId);
        }

        /// <inheritdoc />
        public List<T> Get()
        {
            return _simObjects.Values.ToList();
        }

        /// <inheritdoc />
        public List<T> GetWithRequest()
        {
            Clear();
            Request();
            bool success = _getResetEvent.WaitOne(30*1000);

            if (!success) throw new Exception("Timed out waiting for complete sim objects list.");

            return _simObjects.Values.ToList();
        }

        /// <inheritdoc />
        public void Request()
        {
            _fsConnect.RequestData(_requestId, _definitionId, Radius, SimObjectType);
        }

        /// <inheritdoc />
        public void Clear()
        {
            _simObjects.Clear();
        }

        public void Dispose() => Dispose(true);

        private void HandleReceivedFsData(object sender, FsDataReceivedEventArgs e)
        {
            try
            {
                if (e.RequestId == _requestIdUInt)
                {
                    _simObjects[e.ObjectID] = (T) e.Data;

                    // Set reset event when all items have been returned.
                    if (e.EntryNumber == e.OutOf)
                        _getResetEvent.Set();
                }
            }
            catch
            {
                // Ignored
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _fsConnect.FsDataReceived -= HandleReceivedFsData;
            }

            _disposed = true;
        }
    }
}
