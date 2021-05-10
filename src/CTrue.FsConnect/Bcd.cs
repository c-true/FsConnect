namespace CTrue.FsConnect
{
    /// <summary>
    /// Handles the BCD format
    /// </summary>
    public static class Bcd
    {
        /// <summary>
        /// Converts from binary coded decimal to integer
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static uint Bcd2Dec(uint num) { return HornerScheme(num, 0x10, 10); }

        /// <summary>
        /// Converts from integer to binary coded decimal
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static uint Dec2Bcd(uint num) { return HornerScheme(num, 10, 0x10); }

        private static uint HornerScheme(uint Num, uint Divider, uint Factor)
        {
            uint Remainder = 0, Quotient = 0, Result = 0;
            Remainder = Num % Divider; Quotient = Num / Divider;

            if (!(Quotient == 0 && Remainder == 0))
                Result += HornerScheme(Quotient, Divider, Factor) * Factor + Remainder; return Result;
        }
    }
}