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
        public void SetCom1StandbyFrequencies()
        {
            // Arrange
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            FsConnect fsConnect = new FsConnect();
            fsConnect.ConnectionChanged += (sender, b) =>
            {
                if (b) resetEvent.Set();
            };
            fsConnect.FsError += (sender, args) =>
            {
                Assert.Fail($"MSFS Error: {args.ExceptionDescription}");
            };

            fsConnect.Connect("FsConnectManagersIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            RadioManager manager = new RadioManager(fsConnect);

            // Set - Act

            double freq = 124.75d;

            manager.SetCom1StandbyFrequency(freq);

            // Set - Assert
            manager.Update();
            Assert.That(manager.Com1StandbyFrequency, Is.EqualTo(freq));

            // Swap - Act
            manager.Com1Swap();

            // Swap - Assert
            manager.Update();
            Assert.That(manager.Com1ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetCom2StandbyFrequencies()
        {
            // Arrange
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            FsConnect fsConnect = new FsConnect();
            fsConnect.ConnectionChanged += (sender, b) =>
            {
                if (b) resetEvent.Set();
            };
            fsConnect.FsError += (sender, args) =>
            {
                Assert.Fail($"MSFS Error: {args.ExceptionDescription}");
            };

            fsConnect.Connect("FsConnectManagersIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            RadioManager manager = new RadioManager(fsConnect);

            // Set - Act

            double freq = 118.10d;

            manager.SetCom2StandbyFrequency(freq);

            // Set - Assert
            manager.Update();
            Assert.That(manager.Com2StandbyFrequency, Is.EqualTo(freq).Within(0.01));

            // Swap - Act
            manager.Com2Swap();

            // Swap - Assert
            manager.Update();
            Assert.That(manager.Com2ActiveFrequency, Is.EqualTo(freq).Within(0.01));
        }

        [Test]
        public void SetCom1StandbyFrequenciesInHz()
        {
            // Arrange
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            FsConnect fsConnect = new FsConnect();
            fsConnect.ConnectionChanged += (sender, b) =>
            {
                if (b) resetEvent.Set();
            };
            fsConnect.FsError += (sender, args) =>
            {
                Assert.Fail($"MSFS Error: {args.ExceptionDescription}");
            };

            fsConnect.Connect("FsConnectManagersIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            RadioManager manager = new RadioManager(fsConnect);

            // Set - Act

            double freq = 124.775d;

            manager.SetCom1StandbyFrequencyInHz(freq);

            //// Set - Assert
            //manager.Update();
            //Assert.That(manager.Com1StandbyFrequency, Is.EqualTo(freq));

            //// Swap - Act
            //manager.Com1Swap();

            //// Swap - Assert
            //manager.Update();
            //Assert.That(manager.Com1ActiveFrequency, Is.EqualTo(freq));
        }
    }
}
