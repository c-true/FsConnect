using System.Collections.Generic;

namespace CTrue.FsConnect
{
    public enum FsUnit
    {
        None,
        Degrees,
        Radians,
        Feet,
        Meter,
        MeterPerSecond
    }

    public static class UnitFactory
    {
        private static Dictionary<FsUnit, string> _enumToCodeDictionary = new Dictionary<FsUnit, string>();

        static UnitFactory()
        {
            _enumToCodeDictionary.Add(FsUnit.None, null);
            _enumToCodeDictionary.Add(FsUnit.Degrees, "degrees");
            _enumToCodeDictionary.Add(FsUnit.Radians, "radians");
            _enumToCodeDictionary.Add(FsUnit.Feet, "feet");
            _enumToCodeDictionary.Add(FsUnit.Meter, "meter");
            _enumToCodeDictionary.Add(FsUnit.MeterPerSecond, "meter per second");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static string GetUnitCode(FsUnit unit)
        {
            return _enumToCodeDictionary[unit];
        }
    }
}