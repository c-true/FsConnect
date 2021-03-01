using System;
using System.Runtime.InteropServices;

namespace CTrue.FsConnect.TestConsole
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlaneInfoResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        public double Latitude;
        public double Longitude;
        public double AltitudeAboveGround;
        public double Altitude;
        public double Heading;
        public double Speed;
        public double AbsoluteTime;
    };
}
