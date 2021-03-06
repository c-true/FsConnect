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

        public override string ToString()
        {
            return $"Time: {AbsoluteTime:F1}, Pos: ({FsUtils.Rad2Deg(Latitude):F4}, {FsUtils.Rad2Deg(Longitude):F4}), Alt: {Altitude:F0} ft, Hdg: {FsUtils.Rad2Deg(Heading):F1} deg, Speed: {Speed:F0} kt";

        }
    };
}
