using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.FlightSimulator.SimConnect;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class SimVarReflectorTest
    {
        [Test]
        public void Test()
        {
            SimVarReflector reflector = new SimVarReflector();

            List<SimVar> list = reflector.GetSimVars<SimConnectObject>();

            Assert.That(list, Is.Not.Null);
            Assert.That(list.Count, Is.EqualTo(10));

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
            
            Assert.That(list[7].Name, Is.EqualTo("GENERAL ENG STARTER:1"));
            Assert.That(list[7].Unit, Is.EqualTo("Bool"));
            Assert.That(list[7].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.INT32));

            Assert.That(list[8].Name, Is.EqualTo("GENERAL ENG STARTER:2"));
            Assert.That(list[8].Unit, Is.EqualTo("Bool"));
            Assert.That(list[8].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.INT32));

            Assert.That(list[9].Name, Is.EqualTo("GENERAL ENG STARTER:3"));
            Assert.That(list[9].Unit, Is.EqualTo("Bool"));
            Assert.That(list[9].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.INT32));
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SimConnectObject
    {
        // #0
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string Title;

        // #1
        [SimVar(Name = "Category")]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string A256CharString;

        // #2
        [SimVar(NameId = FsSimVar.NavName)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string A128CharString;

        // #3
        [SimVar(NameId = FsSimVar.PlaneAltitude, Unit = "feet")]
        public double Altitude;

        // #4
        [SimVar(Unit = "feet")]
        public double PlaneAltitude;

        // #5
        [SimVar(UnitId = FsUnit.Meter)]
        public double Plane_Altitude;

        // #6
        [SimVar(UnitId = FsUnit.Meter)]
        public float PlaneAltAboveGround;
        
        // #7
        [SimVar(UnitId = FsUnit.Bool)]
        public bool GeneralEngStarter1;

        // #8
        [SimVar(UnitId = FsUnit.Bool)]
        public bool GeneralEngStarter2;

        // #9
        [SimVar(NameId = FsSimVar.GeneralEngStarter, UnitId = FsUnit.Bool, Instance = 3)]
        public bool MyEngineNumberThreeStarter4;


        public double APropertyThatIsIgnored { get; set; }

        private double APrivateFieldIsIgnored;
    };
}
