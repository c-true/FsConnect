using System;

namespace CTrue.FsConnect
{
    /// <summary>
    /// Utilities for handling Flight Simulator
    /// </summary>
    public class FsUtils
    {
        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double Deg2Rad(double deg)
        {
            return deg * Math.PI / 180;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        public static double Rad2Deg(double rad)
        {
            return rad * 180 / Math.PI;
        }
    }
}