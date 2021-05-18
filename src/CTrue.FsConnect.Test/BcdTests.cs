using System;
using NUnit.Framework;

namespace CTrue.FsConnect.Test
{
    [TestFixture]
    public class BcdTests
    {
        [Test]
        public void Test()
        {
            /*
            def to_radio_bcd16(val):
              encodable = int(val * 100)
              remainder = ((val * 100) - encodable) / 100.0
              return int(str(encodable), 16), round(remainder,3), val
             */
            double freq = 128.775;
            uint freq1 = (uint)(freq * 100);
            double remainder = ((freq * 100) - freq1) / 100.0;
            var bcd = Bcd.Dec2Bcd(freq1);
            var freq2 = Bcd.Bcd2Dec(bcd);
            

            Assert.That(freq2, Is.EqualTo(freq1));

            //Assert.That(ToRadioBcd(128.775), Is.EqualTo(75895));

        }

        [Test]
        public void Test2()
        {
            double freq = 128.775;

            // Act
            var bcd = Bcd.Dec2Bcd(freq);

            // Assert
            var freqOutUint = Bcd.Bcd2Dec(bcd);
            var freqOutDouble = (double)freqOutUint / 100;
            
            Assert.That(freqOutDouble, Is.EqualTo(freq));
        }
    }
}