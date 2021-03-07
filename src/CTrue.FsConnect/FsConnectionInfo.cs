using System;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Contains key information about the connection to Flight Simulator.
    /// </summary>
    public class FsConnectionInfo
    {
        public bool Connected { get; set; }
        public string ApplicationName { get; internal set; } = "";
        public string ApplicationVersion { get; internal set; }
        public string ApplicationBuild { get; internal set; }
        public string SimConnectVersion { get; internal set; }
        public string SimConnectBuild { get; internal set; }
    }
}