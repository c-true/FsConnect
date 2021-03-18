using System;
using System.Collections.Generic;

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
        /// The ID of the object that the update is for.
        /// </summary>
        public uint ObjectID { get; set; }

        /// <summary>
        /// The ID of the client defined data definition.
        /// </summary>
        public uint DefineId { get; set; }

        /// <summary>
        /// 	The flags that were set for this data request, see SimConnect_RequestDataOnSimObject for a description of the flags. This parameter will always be set to zero if the call was SimConnect_RequestDataOnSimObjectType.
        /// </summary>
        public uint Flags { get; set; }

        /// <summary>
        /// The data that was received.
        /// </summary>
        public List<object> Data { get; set; }
        
        /// <summary>
        /// If multiple objects are being returned, this is the index number of this object out of a total of <see cref="OutOf"/>. This will always be 1 if the call was SimConnect_RequestDataOnSimObject, and can be 0 or more if the call was SimConnect_RequestDataOnSimObjectType.
        /// </summary>
        public uint EntryNumber { get; set; }

        /// <summary>
        /// The total number of objects being returned. Note that <see cref="EntryNumber"/> and <see cref="OutOf"/> start with 1 not 0, so if two objects are being  returned <see cref="EntryNumber"/> and <see cref="OutOf"/> pairs will be 1,2 and 2,2 for the two objects. This will always be 1 if the call was SimConnect_RequestDataOnSimObject, and can be 0 or more if the call was SimConnect_RequestDataOnSimObjectType.
        /// </summary>
        public uint OutOf { get; set; }
        
        /// <summary>
        /// The number of items in the data list.
        /// </summary>
        public uint DefineCount { get; set; }

        /// <summary>
        /// Number of objects returned.
        /// </summary>
        public int DataItemCount { get; set; }
    }
}