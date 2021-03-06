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
        public uint ApplicationVersionMajor { get; internal set; }
        public uint ApplicationVersionMinor { get; internal set; }
        public uint ApplicationBuildMajor { get; internal set; }
        public uint ApplicationBuildMinor { get; internal set; }
        public uint SimConnectVersionMajor { get; internal set; }
        public uint SimConnectVersionMinor { get; internal set; }
        public uint SimConnectBuildMajor { get; internal set; }
        public uint SimConnectBuildMinor { get; internal set; }
    }
}