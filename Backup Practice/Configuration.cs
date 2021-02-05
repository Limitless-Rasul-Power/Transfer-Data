using System;

namespace Backup_Practice
{
    public sealed class Configuration
    {
        public static string[] GetCategories()
        {
            string[] categories = { "HDD", "Flash Drive", "DVD", "Exit" };
            return categories;
        }

        public static string[] GetOptions()
        {
            string[] options = { "Tranfer Right Now", "How long does it take to tranfer data ?(Information about how many minutes)", "Show Drive Information", "Back" };
            return options;
        }
        public static void Print(in string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
                Console.WriteLine($"{i + 1}.{menu[i]}");
        }

        public static Storage[] GetStorages()
        {
            HDD hdd = new HDD("HDD", "Super Nova", 23, 300);
            FlashDrive flash = new FlashDrive("Flash Drive", "SanDisc", 10, 256);
            DVD dvd = new DVD("DVD", "Razer", 19, DVD.Type.TwoSided);

            Storage[] storages = { hdd, flash, dvd };
            return storages;
        }

    }
}
