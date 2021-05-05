using System;
using System.Runtime.InteropServices;
using System.Threading;
using NUnit.Framework;

namespace CTrue.FsConnect.Managers.Test
{
    /// <summary>
    /// World manager integration tests.
    /// </summary>
    /// <remarks>
    /// Load MSFS and an aircraft before running.
    /// Observe that the time changes in the simulator.
    /// </remarks>
    [TestFixture(Explicit = true)]
    public class AircraftManagersIntegrationTests
    {
        [Test]
        public void GetAircraftData()
        {
            // Arrange
            AutoResetEvent resetEvent = new AutoResetEvent(false);
            int errorCount = 0;

            FsConnect fsConnect = new FsConnect();
            fsConnect.ConnectionChanged += (sender, b) =>
            {
                if (b) resetEvent.Set();
            };
            fsConnect.FsError += (sender, args) =>
            {
                errorCount++;
                Console.WriteLine($"Error: {args.ExceptionDescription}");
            };

            fsConnect.Connect("AircraftManagersIntegrationTests", 0);

            bool res = resetEvent.WaitOne(2000);
            if(!res) Assert.Fail("Not connected to MSFS within timeout");

            var defId = fsConnect.RegisterDataDefinition<AircraftInfo>();

            AircraftManager<AircraftInfo> aircraftManager = new AircraftManager<AircraftInfo>(fsConnect, defId);

            // Act
            var info = aircraftManager.Get();

            // Assert
            Assert.That(errorCount, Is.Zero);
            Assert.That(info.Title, Is.Not.Empty);
            Assert.That(info.Latitude, Is.Not.EqualTo(0));
            Assert.That(info.Longitude, Is.Not.EqualTo(0));
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct AircraftInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Title;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String Category;
        [SimVar(NameId = FsSimVar.PlaneLatitude, UnitId = FsUnit.Radian)]
        public double Latitude;
        [SimVar(NameId = FsSimVar.PlaneLongitude, UnitId = FsUnit.Radian)]
        public double Longitude;
        [SimVar(NameId = FsSimVar.PlaneAltitudeAboveGround, UnitId = FsUnit.Feet)]
        public double AltitudeAboveGround;
        [SimVar(NameId = FsSimVar.PlaneAltitude, UnitId = FsUnit.Feet)]
        public double Altitude;
        [SimVar(NameId = FsSimVar.PlaneHeadingDegreesTrue, UnitId = FsUnit.Degree)]
        public double Heading;
        [SimVar(NameId = FsSimVar.AirspeedTrue, UnitId = FsUnit.Knot)]
        public double Speed;
    };
}
