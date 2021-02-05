using System;

namespace Backup_Practice
{
    public partial class HDD : Storage
    {
        private double _usb3Speed;
        private double _memory;
        private double _usedMemory = default;

        public HDD(in string mediaName, in string model, in double usb3Speed, in double memory)
            : base(mediaName, model)
        {
            USB3Speed = usb3Speed;
            Memory = memory;
        }
    }
}
