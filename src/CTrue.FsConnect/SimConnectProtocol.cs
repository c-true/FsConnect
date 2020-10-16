using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Specifies the protocol to use to connect to Flight Simulator.
    /// </summary>
    public enum SimConnectProtocol
    {
        /// <summary>
        /// Named pipes
        /// </summary>
        Pipe,

        /// <summary>
        /// TCP.IP v4
        /// </summary>
        Ipv4,
        
        /// <summary>
        /// TCP.IP v6
        /// </summary>
        Ipv6
    }
}
