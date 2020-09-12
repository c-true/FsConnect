using System;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Used to hold data received from Flight Simulator.
    /// </summary>
    public class FsDataReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// The request id of the received data.
        /// </summary>
        public uint RequestId { get; set; }
        
        /// <summary>
        /// The data that was received.
        /// </summary>
        public object Data { get; set; }
    }
}