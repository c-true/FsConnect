using System;
using System.Runtime.InteropServices;

namespace CTrue.FsConnect.TestConsole
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlaneInfoResponse
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Category;
        public double Latitude;
        public double Longitude;
        public double AltitudeAboveGround;
        public double Altitude;
        public double Heading;
        public double Speed;

        public override string ToString()
        {
            return $"Title: {Title}, Category: {Category}, Pos: ({FsUtils.Rad2Deg(Latitude):F4}, {FsUtils.Rad2Deg(Longitude):F4}), Alt: {Altitude:F0} ft, Hdg: {Heading:F1} deg, Speed: {Speed:F0} kt";

        }
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlanePosition
    {
        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Heading;

        public override string ToString()
        {
            return $"Pos: ({Latitude:F4}, {Longitude:F4}), Alt: {Altitude:F0} ft, Hdg: {Heading:F1} deg";

        }
    };
}
