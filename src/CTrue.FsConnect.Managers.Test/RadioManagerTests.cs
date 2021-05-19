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
        private FsConnect _fsConnect;
        private RadioManager _manager;

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

            _fsConnect.Connect("RadioManagerIntegrationTest", 0);

            bool res = resetEvent.WaitOne(2000);
            if (!res) Assert.Fail("Not connected to MSFS within timeout");

            _manager = new RadioManager(_fsConnect);
        }

        [Test]
        public void Update()
        {
            // Arrange
            // Act
            _manager.Update();

            // Assert
            Assert.That(_manager.Com1StandbyFrequency, Is.GreaterThan(118));
        }

        [Test]
        public void SetCom1StandbyFrequency()
        {
            // Arrange
            double freq = 124.774d;

            // Act
            _manager.SetCom1StandbyFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Com1StandbyFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetCom1ActiveFrequency()
        {
            // Arrange
            double freq = 124.774d;

            // Act
            _manager.SetCom1ActiveFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Com1ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetCom2StandbyFrequency()
        {
            // Arrange
            double freq = 124.774d;

            // Act
            _manager.SetCom2StandbyFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Com2StandbyFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetCom2ActiveFrequency()
        {
            // Arrange
            double freq = 124.773d;

            // Act
            _manager.SetCom2ActiveFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Com2ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SwapCom1()
        {
            // Arrange
            double freq = 124.773d;
            _manager.SetCom1StandbyFrequency(freq);
            _manager.SetCom1ActiveFrequency(125.000d);

            // Act
            _manager.Com1Swap();

            // Assert
            _manager.Update();
            Assert.That(_manager.Com1ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SwapCom2()
        {
            // Arrange
            double freq = 124.773d;
            _manager.SetCom2StandbyFrequency(freq);
            _manager.SetCom2ActiveFrequency(125.000d);

            // Act
            _manager.Com2Swap();

            // Assert
            _manager.Update();
            Assert.That(_manager.Com2ActiveFrequency, Is.EqualTo(freq));
        }

        #region NAV

        [Test]
        public void SetNav1StandbyFrequency()
        {
            // Arrange
            double freq = 110.7;

            // Act
            _manager.SetNav1StandbyFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Nav1StandbyFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetNav1ActiveFrequency()
        {
            // Arrange
            double freq = 110.7;

            // Act
            _manager.SetNav1ActiveFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Nav1ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetNav2StandbyFrequency()
        {
            // Arrange
            double freq = 110.7;

            // Act
            _manager.SetNav2StandbyFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Nav2StandbyFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SetNav2ActiveFrequency()
        {
            // Arrange
            double freq = 110.7;

            // Act
            _manager.SetNav2ActiveFrequency(freq);

            // Assert
            _manager.Update();
            Assert.That(_manager.Nav2ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SwapNav1()
        {
            // Arrange
            double freq = 110.7;
            _manager.SetNav1StandbyFrequency(freq);
            _manager.SetNav1ActiveFrequency(125.000d);

            // Act
            _manager.Nav1Swap();

            // Assert
            _manager.Update();
            Assert.That(_manager.Nav1ActiveFrequency, Is.EqualTo(freq));
        }

        [Test]
        public void SwapNav2()
        {
            // Arrange
            double freq = 110.7;
            _manager.SetNav2StandbyFrequency(freq);
            _manager.SetNav2ActiveFrequency(125.000d);

            // Act
            _manager.Nav2Swap();

            // Assert
            _manager.Update();
            Assert.That(_manager.Nav2ActiveFrequency, Is.EqualTo(freq));
        }

        #endregion
    }
}
