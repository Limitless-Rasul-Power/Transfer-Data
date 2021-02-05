using System;
using System.Windows.Forms;

namespace Backup_Practice
{
    public partial class FlashDrive : Storage
    {
        public double USB2Speed
        {
            get
            {
                return _usb2Speed;
            }
            private set
            {
                if (Verify.IsInputNotPositiveNumber(value.ToString()))
                    throw new InvalidOperationException("Input must be number.");

                _usb2Speed = value;
                ConvertData.MegabitPerSecondsToBitPerSeconds(ref _usb2Speed);
            }
        }

        public double Memory
        {
            get
            {
                return _memory;
            }
            private set
            {
                if (Verify.IsInputNotPositiveNumber(value.ToString()))
                    throw new InvalidOperationException("Input must be number.");

                _memory = value;
                ConvertData.GigaByteToBit(ref _memory);
            }
        }

        
        public override void HowLongTakeToTransferData(in string dataSizeWithGB)
        {
            try
            {
                double dataSizeWithBits = TransferHelper.HandleTransferdData(dataSizeWithGB);
                Console.WriteLine($"{(long) ((dataSizeWithBits / USB2Speed) / 60)} minutes take to transfer data in Flash Drive.");
            }
            catch (InvalidOperationException caption)
            {
                Console.Clear();
                MessageBox.Show(caption.Message, "Transformer Coo inc ©", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void Copy(in string dataSizeWithGB)
        {
            try
            {
                double dataSizeWithBits = TransferHelper.HandleTransferdData(dataSizeWithGB);
                double minute = (dataSizeWithBits / USB2Speed) / 60;
                MemoryHelper.ReevaluateMemory(dataSizeWithBits, _memory, ref _usedMemory);

                Console.WriteLine($"Data transferred {(long)minute} minutes with Flash Drive.");
                //Network.MailHelper.SendEmail(Network.MailHelper.MyEmail, $"Data transferred {minute} minutes with Flash Drive.");
            }
            catch (InvalidOperationException caption)
            {
                Console.Clear();
                MessageBox.Show(caption.Message, "Transformer Coo inc ©", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override double GetFreeMemory()
        {
            return Memory - _usedMemory;
        }

        public override void PrintDeviceInformation()
        {
            base.PrintDeviceInformation();
            Console.WriteLine("\nFlash Drive Information");
            Console.WriteLine($"USB 2.0 Speed: {USB2Speed / ConvertData.MegabitPerSecondToBitPerSecond} megabits/second");
            Console.WriteLine($"Memory: {Memory / ConvertData.GBtoBit} GB");
            Console.WriteLine($"Free Memory: {GetFreeMemory() / ConvertData.GBtoBit} GB");
            Console.WriteLine("===============================");
        }

    }
}
