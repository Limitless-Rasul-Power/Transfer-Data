using System;
using System.Windows.Forms;

namespace Backup_Practice
{
    public partial class DVD : Storage
    {
        public enum Type
        {
            OneSided = 1, TwoSided = 2
        }
        public double ReadWriteSpeed
        {
            get
            {
                return _readWriteSpeed;
            }
            private set
            {
                if (Verify.IsInputNotPositiveNumber(value.ToString()))
                    throw new InvalidOperationException("Input must be number.");

                _readWriteSpeed = value;
                ConvertData.MegabitPerSecondsToBitPerSeconds(ref _readWriteSpeed);
            }
        }
        public DVD.Type TypeOfDVD
        {
            get
            {
                return _typeOfDVD;
            }
            private set
            {
                if (Verify.IsDVDTypeNotExist(value))
                    throw new InvalidOperationException("DVD type must be \"One Sided\" or \"Two Sided\".");

                _typeOfDVD = value;

                _memory = (_typeOfDVD == DVD.Type.OneSided) ? DVDSpecialities.OneSidedMemory : DVDSpecialities.TwoSidedMemory;
                ConvertData.GigaByteToBit(ref _memory);
            }
        }


        public override void HowLongTakeToTransferData(in string dataSizeWithGB)
        {
            try
            {
                double dataSizeWithBits = TransferHelper.HandleTransferdData(dataSizeWithGB);
                Console.WriteLine($"{(long) ((dataSizeWithBits / ReadWriteSpeed) / 60)} minutes take to transfer data in DVD.");
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
                double minute = (dataSizeWithBits / ReadWriteSpeed) / 60;
                MemoryHelper.ReevaluateMemory(dataSizeWithBits, _memory, ref _usedMemory);

                Console.WriteLine($"Data transferred {(long)minute} minutes with DVD.");
                //Network.MailHelper.SendEmail(Network.MailHelper.MyEmail, $"Data transferred {minute} minutes with DVD.");
            }
            catch (InvalidOperationException caption)
            {
                Console.Clear();
                MessageBox.Show(caption.Message, "Transformer Coo inc ©", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override double GetFreeMemory()
        {
            return _memory - _usedMemory;
        }

        public override void PrintDeviceInformation()
        {
            base.PrintDeviceInformation();
            Console.WriteLine("\nFlash Drive Information");
            Console.WriteLine($"DVD Type: {TypeOfDVD}");
            Console.WriteLine($"Read/Write Speed: {ReadWriteSpeed / ConvertData.MegabitPerSecondToBitPerSecond} megabits/second");
            Console.WriteLine($"Memory: {_memory / ConvertData.GBtoBit} GB");
            Console.WriteLine($"Free Memory: {GetFreeMemory() / ConvertData.GBtoBit} GB");
            Console.WriteLine("===============================");
        }

    }
}
