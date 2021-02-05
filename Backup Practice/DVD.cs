using System;

namespace Backup_Practice
{
    public partial class DVD : Storage
    {
        private double _readWriteSpeed;
        private DVD.Type _typeOfDVD;
        private double _memory;
        private double _usedMemory = default;

        public DVD(in string mediaName, in string model, in double readWriteSpeed, in DVD.Type type)
            : base(mediaName, model)
        {
            ReadWriteSpeed = readWriteSpeed;
            TypeOfDVD = type;
        }
    }
}
