using System;
using Microsoft.FlightSimulator.SimConnect;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Used to hold data received from Flight Simulator.
    /// </summary>
    public class ObjectAddRemoveEventReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets whether the Sim Object was added, or removed.
        /// </summary>
        public bool Added { get; set; }

        /// <summary>
        /// The request id of the received data.
        /// </summary>
        public uint RequestId { get; set; }

        /// <summary>
        /// The data that was received.
        /// </summary>
        public object Data { get; set; }

        public SIMCONNECT_SIMOBJECT_TYPE ObjectType { get; set; }

        /// <summary>
        /// The Object Id of the added or removed Sim Object.
        /// </summary>
        public uint ObjectID { get; set; }
    }
}