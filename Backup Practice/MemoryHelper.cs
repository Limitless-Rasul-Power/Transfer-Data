using System;

namespace Backup_Practice
{
    public static class MemoryHelper
    {
        public static void ReevaluateMemory(in double transferredData, in double memory, ref double usedMemory)
        {
            if (usedMemory + transferredData > memory || memory < 0 || usedMemory < 0 || transferredData <= 0)
                throw new InvalidOperationException("Transferred data is more than drive's memory or one of this values are negative or transferred data is 0!");

            usedMemory += transferredData;
        }
    }
}
