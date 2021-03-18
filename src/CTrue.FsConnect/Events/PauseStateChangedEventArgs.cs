using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTrue.FsConnect
{
    public class PauseStateChangedEventArgs : EventArgs
    {
        public bool Paused { get; set; }
    }
}
