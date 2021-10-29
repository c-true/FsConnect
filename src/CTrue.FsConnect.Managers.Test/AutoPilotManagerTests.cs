using System.Threading;
using NUnit.Framework;

namespace CTrue.FsConnect.Managers.Test
{
    [TestFixture(Explicit = true)]
    public class AutopilotManagerTests
    {
        private FsConnect _fsConnect;
        private AutopilotManager _manager;

        [SetUp]
        public void SetUp()
        {
            AutoResetEvent resetEvent = new AutoResetEvent(false);

            _fsConnect = new FsConnect();
            _fsConnect.ConnectionChanged += (sender, b) =>
            {
                if (b) resetEvent.Set();
            };
            _fsConnect.FsError += (sender, args) =>
            {
                Assert.Fail($"MSFS Error: {args.ExceptionDescription}");
            };

            _fsConnect.Connect("AutopilotManagerIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            _manager = new AutopilotManager(_fsConnect);
            _manager.Initialize();
        }

        [Test]
        public void Update()
        {
            // Arrange
            // Act
            _manager.Update();

            // Assert
            Assert.That(_manager.HeadingBug, Is.GreaterThan(0));
            Assert.That(_manager.Altitude, Is.GreaterThan(0));
            Assert.That(_manager.VerticalSpeed, Is.GreaterThan(0));
        }

        [Test]
        public void SetHeadingBug()
        {
            // Arrange
            double heading = 42;

            // Act
            _manager.SetHeadingBug(heading);

            // Assert
            _manager.Update();
            Assert.That(_manager.HeadingBug, Is.EqualTo(heading));
        }


        [Test]
        public void SetAltitudeLock()
        {
            // Arrange
            double altitude = 14000;

            // Act
            _manager.SetAltitude(altitude);

            // Assert
            _manager.Update();
            Assert.That(_manager.Altitude, Is.EqualTo(altitude));
        }



        [Test]
        public void SetVerticalSpeed()
        {
            // Arrange
            double verticalSpeed = 800;

            // Act
            _manager.SetVerticalSpeed(verticalSpeed);

            // Assert
            _manager.Update();
            Assert.That(_manager.VerticalSpeed, Is.EqualTo(verticalSpeed));
        }
    }
}