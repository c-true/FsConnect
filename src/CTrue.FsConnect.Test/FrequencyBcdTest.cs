using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class FrequencyBcdTest
    {
        [Test]
        public void Test()
        {
            FrequencyBcd freq = new FrequencyBcd(128.775);

            Assert.That(freq.Bcd16Value, Is.EqualTo(75895));

            FrequencyBcd freq2 = new FrequencyBcd(freq.Bcd16Value);

            Assert.That(freq2.Value, Is.EqualTo(128.75));
        }

        [Test]
        public void Test2([Values(124.00, 127.90)] double frequency)
        {
            // Act
            FrequencyBcd freq = new FrequencyBcd(frequency);
            FrequencyBcd freq2 = new FrequencyBcd(freq.Bcd16Value);

            // Assert
            Assert.That(freq2.Value, Is.EqualTo(frequency));
        }
    }
}