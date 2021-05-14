using System;

namespace CTrue.FsConnect
{
    public class FrequencyBcd
    {
        private double _value = 0;
        private uint _bcdValue = 0;

        public double Value => _value;

        /// <summary>
        /// Gets the BCD encoded
        /// </summary>
        public uint BcdValue => _bcdValue;

        public FrequencyBcd(double freqValue)
        {
            _value = freqValue;

            uint encodable = (uint)((_value - 100) * 100);
            double remainder = ((_value * 100) - encodable) / 100.0;

            _bcdValue = Bcd.Dec2Bcd(encodable);
        }

        public FrequencyBcd(uint bcdValue)
        {
            _bcdValue = bcdValue;
            var freqOutUint = Bcd.Bcd2Dec(_bcdValue);
            var tmp = freqOutUint + 10000;
            _value = (double)tmp / 100;
            //_value = Math.Round(_value * 4, MidpointRounding.ToEven) / 4;
        }
    }
}