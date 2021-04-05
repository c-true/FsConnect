using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.FlightSimulator.SimConnect;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class SimPropertyReflectorTest
    {
        [Test]
        public void Test()
        {
            SimPropertyReflector reflector = new SimPropertyReflector();

            List<SimProperty> list = reflector.GetSimProperties<SimConnectObject>();

            Assert.That(list, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(7));

            Assert.That(list[0].Name, Is.EqualTo("TITLE"));
            Assert.That(list[0].Unit, Is.EqualTo(""));
            Assert.That(list[0].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.STRING256));

            Assert.That(list[1].Name, Is.EqualTo("Category"));
            Assert.That(list[1].Unit, Is.EqualTo(""));
            Assert.That(list[1].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.STRING256));

            Assert.That(list[2].Name, Is.EqualTo("NAV NAME"));
            Assert.That(list[2].Unit, Is.EqualTo(""));
            Assert.That(list[2].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.STRING128));

            Assert.That(list[3].Name, Is.EqualTo("PLANE ALTITUDE"));
            Assert.That(list[3].Unit, Is.EqualTo("feet"));
            Assert.That(list[3].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.FLOAT64));

            Assert.That(list[4].Name, Is.EqualTo("PLANE ALTITUDE"));
            Assert.That(list[4].Unit, Is.EqualTo("feet"));
            Assert.That(list[4].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.FLOAT64));

            Assert.That(list[5].Name, Is.EqualTo("PLANE ALTITUDE"));
            Assert.That(list[5].Unit, Is.EqualTo("meter"));
            Assert.That(list[5].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.FLOAT64));

            Assert.That(list[6].Name, Is.EqualTo("PLANE ALT ABOVE GROUND"));
            Assert.That(list[6].Unit, Is.EqualTo("meter"));
            Assert.That(list[6].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.FLOAT32));
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SimConnectObject
    {
        // #0
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Title;

        // #1
        [SimProperty(Name = "Category")]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string A256CharString;

        // #2
        [SimProperty(NameId = FsSimVar.NavName)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string A128CharString;

        // #3
        [SimProperty(NameId = FsSimVar.PlaneAltitude, Unit = "feet")]
        public double Altitude;

        // #4
        [SimProperty(Unit = "feet")]
        public double PlaneAltitude;

        // #5
        [SimProperty(UnitId = FsUnit.Meter)]
        public double Plane_Altitude;

        // #6
        [SimProperty(UnitId = FsUnit.Meter)]
        public float PlaneAltAboveGround;

        public double APropertyThatIsIgnored { get; set; }

        private double APrivateFieldIsIgnored;
    };
}
