using System;

namespace Backup_Practice
{
    public partial class FlashDrive : Storage
    {
        private double _usb2Speed;
        private double _memory;
        private double _usedMemory = default;

        public FlashDrive(in string mediaName, in string model, in double usb2Speed, in double memory)
            : base(mediaName, model)
        {
            USB2Speed = usb2Speed;
            Memory = memory;
        }
    }
}
