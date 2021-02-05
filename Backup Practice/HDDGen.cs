using System;
using System.Windows.Forms;

namespace Backup_Practice
{
    public partial class HDD : Storage
    {
        public double USB3Speed
        {
            get
            {
                return _usb3Speed;
            }
            private set
            {
                if (Verify.IsInputNotPositiveNumber(value.ToString()))
                    throw new InvalidOperationException("Input must be number.");

                _usb3Speed = value;
                ConvertData.MegabitPerSecondsToBitPerSeconds(ref _usb3Speed);
            }
        }
        public double Memory
        {
            get
            {
                return _memory;
            }
            set
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
                Console.WriteLine($"{(long) ((dataSizeWithBits / USB3Speed) / 60)} minutes take to transfer data in HDD.");
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
                double minute = (dataSizeWithBits / USB3Speed) / 60;
                MemoryHelper.ReevaluateMemory(dataSizeWithBits, _memory, ref _usedMemory);

                Console.WriteLine($"Data transferred {(long)minute} minutes with HDD.");
                //Network.MailHelper.SendEmail(Network.MailHelper.MyEmail, $"Data transferred {minute} minutes with HDD.");
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
            Console.WriteLine($"\nHDD INFORMATION");
            Console.WriteLine($"USB 3.0 Speed: {USB3Speed / ConvertData.MegabitPerSecondToBitPerSecond} megabits/second");
            Console.WriteLine($"Memory: {Memory / ConvertData.GBtoBit} GB");
            Console.WriteLine($"Free Memory: {GetFreeMemory() / ConvertData.GBtoBit} GB");
            Console.WriteLine("===============================");
        }

    }
}
