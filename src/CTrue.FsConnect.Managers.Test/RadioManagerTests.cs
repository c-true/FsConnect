using System;
using System.Threading;
using NUnit.Framework;

namespace CTrue.FsConnect.Managers.Test
{
    /// <summary>
    /// Radio manager integration tests.
    /// </summary>
    /// <remarks>
    /// Load MSFS and an aircraft before running.
    /// </remarks>
    [TestFixture(Explicit = true)]
    public class RadioManagerTests
    {
        [Test]
        public void SetComStandbyFrequencies()
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

            fsConnect.Connect("FsConnectManagersIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if(!res) Assert.Fail("Not connected to MSFS within timeout");

            RadioManager manager = new RadioManager(fsConnect);

            // Act

            // Values
            uint x = 0x2797;
            uint y = 0x3625;
            uint z = 0x2407;

            manager.SetCom1StandbyFrequency(x);
            manager.SetCom2StandbyFrequency(y);

            fsConnect.SetText("Observe COM1&COM2 Standby frequencies have changed", 1000);

            manager.Update();
            
            // Assert
            Assert.That(errorCount, Is.Zero);
            Assert.That(manager.Com1StandbyFrequency, Is.EqualTo(2797));
            Assert.That(manager.Com2StandbyFrequency, Is.EqualTo(3625));
        }
    }
}
