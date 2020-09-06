using System;

namespace CTrue.FsConnect
{
    public class FsErrorEventArgs : EventArgs
    {
        public uint Exception { get; set; }
        public uint SendID { get; set; }
        public uint Index { get; set; }
        public string ExceptionDescription { get; set; }
    }
}