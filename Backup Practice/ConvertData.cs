namespace Backup_Practice
{
    public static class ConvertData
    {
        public static readonly double GBtoMB = 1_000;
        public static readonly double GBtoBit = GBtoMB * 8 * 1_000_000;
        public static readonly double MegabitPerSecondToBitPerSecond = 1_000_000;
        public static readonly double OverheadOfTCP = 0.4;
        public static void GigaByteToMegaByte(ref double memory)
        {
            if (memory > 0)
                memory *= GBtoMB;
        }

        public static void GigaByteToBit(ref double memory)
        {
            if (memory > 0)
                memory *= GBtoBit;
        }

        public static void BitToGigaByte(ref double memory)
        {
            if (memory > 0)
                memory /= GBtoBit;
        }

        public static void MegabitPerSecondsToBitPerSeconds(ref double megabitPerSeconds)
        {
            if (megabitPerSeconds > 0)
                megabitPerSeconds *= MegabitPerSecondToBitPerSecond;
        }
    }
}
