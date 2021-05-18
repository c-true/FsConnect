using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.FlightSimulator.SimConnect;
using NUnit.Framework;
namespace CTrue.FsConnect.Test
{
    [TestFixture, Explicit]
    public class FsConnectIntegrationTest
    {
        enum TestEnums
        {
            GroupId = 1234,
            EventId = 1235,
            RequestId
        }

        [Test]
        public void TransmitClientEvent_HeadingBugDirectionSet_SetsHeadingBugDirection()
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

            var hbDef = fsConnect.RegisterDataDefinition<HeadingBugTest>();
            HeadingBugTest headingBugData = default;

            // Act
            fsConnect.MapClientEventToSimEvent(TestEnums.GroupId, TestEnums.EventId, FsEventNameId.HeadingBugSet);
            fsConnect.SetNotificationGroupPriority(TestEnums.GroupId);
            uint headingValue = (uint)DateTime.Now.Second * 6;
            fsConnect.TransmitClientEvent(TestEnums.EventId, (uint)headingValue, TestEnums.GroupId);
            
            // Assert
            Assert.That(errorCount, Is.Zero, "MSFS returned errors. Check console output.");

            fsConnect.FsDataReceived += (sender, args) =>
            {
                var data = args.Data.FirstOrDefault();

                headingBugData = data is HeadingBugTest ? (HeadingBugTest) data : default;

                resetEvent.Set();
            };

            fsConnect.RequestData((int)TestEnums.RequestId, hbDef);
            res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Data not returned from MSFS within timeout");

            Assert.That(headingBugData, Is.Not.Null);
            Assert.That(headingBugData.HeadingBug, Is.EqualTo(headingValue));

            // Teardown
            fsConnect?.Disconnect();
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HeadingBugTest
    {
        [SimVar(NameId = FsSimVar.AutopilotHeadingLockDir, UnitId = FsUnit.Degree)]
        public double HeadingBug;
    }
}