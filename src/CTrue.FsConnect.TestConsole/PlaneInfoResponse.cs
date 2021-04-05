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
        [SimProperty(NameId = FsSimVar.PlaneLatitude, UnitId = FsUnit.Radian)]
        public double Latitude;
        [SimProperty(NameId = FsSimVar.PlaneLongitude, UnitId = FsUnit.Radian)]
        public double Longitude;
        [SimProperty(NameId = FsSimVar.PlaneAltitudeAboveGround, UnitId = FsUnit.Feet)]
        public double AltitudeAboveGround;
        [SimProperty(NameId = FsSimVar.PlaneAltitude, UnitId = FsUnit.Feet)]
        public double Altitude;
        [SimProperty(NameId = FsSimVar.PlaneHeadingDegreesTrue, UnitId = FsUnit.Degree)]
        public double Heading;
        [SimProperty(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.Knot)]
        public double Speed;

        public override string ToString()
        {
            return $"Title: {Title}, Category: {Category}, Pos: ({FsUtils.Rad2Deg(Latitude):F4}, {FsUtils.Rad2Deg(Longitude):F4}), Alt: {Altitude:F0} ft, Hdg: {Heading:F1} deg, Speed: {Speed:F0} kt";

        }
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlanePosition
    {
        [SimProperty(NameId = FsSimVar.PlaneLatitude, UnitId = FsUnit.Degree)]
        public double Latitude;
        [SimProperty(NameId = FsSimVar.PlaneLongitude, UnitId = FsUnit.Degree)]
        public double Longitude;
        [SimProperty(NameId = FsSimVar.PlaneAltitude, UnitId = FsUnit.Feet)]
        public double Altitude;
        [SimProperty(NameId = FsSimVar.PlaneHeadingDegreesTrue, UnitId = FsUnit.Degree)]
        public double Heading;

        public override string ToString()
        {
            return $"Pos: ({Latitude:F4}, {Longitude:F4}), Alt: {Altitude:F0} ft, Hdg: {Heading:F1} deg";

        }
    };
}
