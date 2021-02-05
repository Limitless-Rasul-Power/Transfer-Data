using System;

namespace Backup_Practice
{
    public abstract partial class Storage
    {        
        private string _mediaName;
        private string _model;

        public Storage(in string mediaName, in string model)
        {
            MediaName = mediaName;
            Model = model;
        }

        abstract public double GetFreeMemory();
        abstract public void Copy(in string dataSizeWithGB);
        abstract public void HowLongTakeToTransferData(in string dataSizeWithGB);
    }
}
