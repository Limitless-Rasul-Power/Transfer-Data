using System;

namespace Backup_Practice
{
    public static class Verify
    {
        public static bool IsInputNotPositiveNumber(in string input)
        {
            if(!String.IsNullOrWhiteSpace(input))
            {
                double.TryParse(input, out double result);

                if (result > 0)
                    return false;

            }
            return true;
        }

        public static bool IsDVDTypeNotExist(in DVD.Type type)
        {
            if (type == DVD.Type.OneSided || type == DVD.Type.TwoSided)
                return false;

            return true;
        }

        public static bool IsOptionNotCorrect(in int input, in int maxSize)
        {
            if (input < 1 || input > maxSize)
                return true;

            return false;
        }
    }
}
