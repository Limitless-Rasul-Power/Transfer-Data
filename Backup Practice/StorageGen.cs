using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Backup_Practice
{
    public abstract partial class Storage
    {
        public string Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if ((!Regex.IsMatch(value, @"^[a-zA-Z0-9_ -]+$")) || String.IsNullOrWhiteSpace(value))
                    throw new FormatException("Model contains only letters, digits, underscore and - symbols(including space).");

                _model = value;
            }
        }

        public string MediaName
        {
            get
            {
                return _mediaName;
            }
            private set
            {
                if ((!Regex.IsMatch(value, @"^[a-zA-Z -]+$")))
                    throw new DoesnotContainOnlyLettersException("Media name must contain only letters(including - symbol and space).");

                _mediaName = value;
            }
        }

        virtual public void PrintDeviceInformation()
        {
            Console.WriteLine("STORAGE INFORMATION\n");
            Console.WriteLine($"Media Name: {MediaName}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine("===============================");
        }
    }
}
