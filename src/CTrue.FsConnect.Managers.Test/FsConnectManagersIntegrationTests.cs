using System;
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
    public class FsConnectManagersIntegrationTests
    {
        [Test]
        public void SetTime_SetsTimeInMSFS()
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

            WorldManager worldManager = new WorldManager(fsConnect);

            // Act
            DateTime now = new DateTime();
            DateTime night = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);

            fsConnect.SetText("Setting time to night", 1000);
            worldManager.SetTime(night);

            Thread.Sleep(3000);

            fsConnect.SetText("Setting time to morning", 1000);
            DateTime morning = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0);
            worldManager.SetTime(morning);

            // Assert
            Assert.That(errorCount, Is.Zero);
        }
    }
}
