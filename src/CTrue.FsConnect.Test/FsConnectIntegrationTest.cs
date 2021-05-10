using System;
using System.Threading;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture, Explicit]
    public class FsConnectIntegrationTest
    {
        enum TestEnums
        {
            GroupId=1234,
            EventId=1235
        }

        [Test]
        public void TransmitClientEvent_uint()
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

            fsConnect.Connect("FsConnectIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            // Act
            fsConnect.MapClientEventToSimEvent(TestEnums.GroupId, TestEnums.EventId, FsEventNameId.HeadingBugSet);
            fsConnect.SetNotificationGroupPriority(TestEnums.GroupId);
            
            fsConnect.TransmitClientEvent(TestEnums.EventId, (uint)DateTime.Now.Second*6, TestEnums.GroupId);

            // Assert
            Assert.That(errorCount, Is.Zero);

            // Teardown
            fsConnect?.Disconnect();
        }

        [Test]
        public void TransmitClientEvent_ComStbyRadioSet()
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

            fsConnect.Connect("FsConnectIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            // Act
            fsConnect.MapClientEventToSimEvent(TestEnums.GroupId, TestEnums.EventId, FsEventNameId.Com2StbyRadioSet);
            fsConnect.SetNotificationGroupPriority(TestEnums.GroupId);

            // See
            // https://github.com/odwdinc/Python-SimConnect/issues/73

            uint x = 0x2797;
            uint y = 0x3625;
            uint z = 0x2407;
            fsConnect.TransmitClientEvent(TestEnums.EventId, z, TestEnums.GroupId);

            // Assert
            Assert.That(errorCount, Is.Zero);

            // Teardown
            fsConnect?.Disconnect();
        }
    }
}