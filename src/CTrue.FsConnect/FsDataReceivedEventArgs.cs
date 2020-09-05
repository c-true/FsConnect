using System;

namespace CTrue.FsConnect
{
    public class FsDataReceivedEventArgs : EventArgs
    {
        public uint RequestId { get; set; }
        
        public object Data { get; set; }
    }
}