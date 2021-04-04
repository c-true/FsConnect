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
            Assert.That(list.Count, Is.EqualTo(2));

            Assert.That(list[0].Name, Is.EqualTo("A256CharString"));
            Assert.That(list[0].Unit, Is.EqualTo(""));
            Assert.That(list[0].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.STRING256));

            Assert.That(list[1].Name, Is.EqualTo("ADouble"));
            Assert.That(list[1].Unit, Is.EqualTo("Feet"));
            Assert.That(list[1].DataType, Is.EqualTo(SIMCONNECT_DATATYPE.FLOAT64));
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SimConnectObject
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String A256CharString;
        
        [SimProperty(Unit = "Feet")]
        public double ADouble;
    };
}
