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

        /// <summary>
        /// Gets or sets the type of Sim Object to get from flight simulator.
        /// </summary>
        FsConnectSimobjectType SimObjectType { get; set; }

        /// <summary>
        /// Gets a Sim Object by its Object Id.
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        T GetById(uint objectId);
        
        /// <summary>
        /// Gets a dictionary of Sim Objects, containing the Object Id and instance.
        /// </summary>
        /// <returns></returns>
        Dictionary<uint, T> GetDictionary();

        /// <summary>
        /// Gets the current list of known Sim Objects.
        /// </summary>
        /// <returns></returns>
        List<T> GetList();

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

        public FsConnectSimobjectType SimObjectType { get; set; } = FsConnectSimobjectType.All;

        /// <summary>
        /// Creates a <see cref="SimObjectManager{T}"/> instance.
        /// </summary>
        /// <param name="fsConnect"></param>
        /// <param name="defineId"></param>
        /// <param name="requestId"></param>
        public SimObjectManager(IFsConnect fsConnect, Enum defineId, Enum requestId)
        {
            _fsConnect = fsConnect;

            _fsConnect.FsDataReceived += HandleReceivedFsData;

            _definitionId = defineId;
            _requestId = requestId;
            _requestIdUInt = Convert.ToUInt32(requestId);
        }

        /// <inheritdoc />
        public T GetById(uint objectId)
        {
            if (!_simObjects.ContainsKey(objectId)) return default(T);

            return _simObjects[objectId];
        }

        /// <inheritdoc />
        public List<T> GetList()
        {
            return _simObjects.Values.ToList();
        }

        /// <inheritdoc />
        public Dictionary<uint, T> GetDictionary()
        {
            return _simObjects;
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
                if (e.Data == null || e.Data.Count == 0) throw new Exception("No data returned");

                if (e.RequestId == _requestIdUInt)
                {
                    _simObjects[e.ObjectID] = (T) e.Data.FirstOrDefault();

                    // Set reset event when all items have been returned.
                    if (e.EntryNumber == e.OutOf)
                        _getResetEvent.Set();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not handle received FS data: " + ex);
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
