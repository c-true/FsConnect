using System;

namespace CTrue.FsConnect
{
    public class FrequencyBcd
    {
        private double _value = 0;
        private uint _bcd16Value = 0;
        private uint _bcd32Value = 0;

        public double Value => _value;

        /// <summary>
        /// Gets the BCD encoded as 32 bit.
        /// </summary>
        public uint Bcd32Value => _bcd32Value;

        /// <summary>
        /// Gets the BCD encoded as 16 bit.
        /// </summary>
        public uint Bcd16Value => _bcd16Value;

        public FrequencyBcd(double freqValue)
        {
            _value = freqValue;

            uint encodable = (uint)((_value - 100) * 100);
            double remainder = ((_value * 100) - encodable) / 100.0;

            _bcd16Value = Bcd.Dec2Bcd(encodable);

            Byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(freqValue * 1000000));
            _bcd32Value = BitConverter.ToUInt32(bytes, 0);
        }

        public FrequencyBcd(uint bcd16Value)
        {
            _bcd16Value = bcd16Value;
            var freqOutUint = Bcd.Bcd2Dec(_bcd16Value);
            var tmp = freqOutUint + 10000;
            _value = (double)tmp / 100;
            //_value = Math.Round(_value * 4, MidpointRounding.ToEven) / 4;
        }
    }
}