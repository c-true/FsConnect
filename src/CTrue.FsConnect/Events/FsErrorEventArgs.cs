using System;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Describes information about an error reported by SimConnect.
    /// </summary>
    public class FsErrorEventArgs : EventArgs
    {
        public FsException ExceptionCode { get; set; }
        public uint SendID { get; set; }
        public uint Index { get; set; }
        public string ExceptionDescription { get; set; }
    }
}