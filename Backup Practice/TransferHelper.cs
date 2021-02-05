using System;

namespace Backup_Practice
{
    public static class TransferHelper
    {
        public static void AddOverheadForEncoding(ref string dataSize)
        {
            if((!String.IsNullOrWhiteSpace(dataSize)) && (!Verify.IsInputNotPositiveNumber(dataSize)))
            dataSize = (double.Parse(dataSize) + (double.Parse(dataSize) * ConvertData.OverheadOfTCP)).ToString();
        }
        public static double HandleTransferdData(in string dataSizeWithGB)
        {
            if (Verify.IsInputNotPositiveNumber(dataSizeWithGB))
                throw new InvalidOperationException("Input must be number.");

            double dataSizeWithBits = Convert.ToDouble(dataSizeWithGB);
            ConvertData.GigaByteToBit(ref dataSizeWithBits);

            return dataSizeWithBits;
        }

        public static void TransferringPause()
        {
            Console.ForegroundColor = ConsoleColor.Green; 

            Console.Write(new string('\n', (Console.WindowHeight - 2) / 2));

            Console.Write(new string(' ', (Console.WindowWidth - "Transferring...".Length) / 2));
            Console.WriteLine("Transferring...\n");

            const int length = 10;
            Console.Write(new string(' ', (Console.WindowWidth - (length * 2)) / 2));

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < length; i++)
            {
                Console.Write("█" + " ");
                System.Threading.Thread.Sleep(500);
            }
            Console.ResetColor();
        }
    }
}
