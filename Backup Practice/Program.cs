using System;
using System.Windows.Forms;

namespace Backup_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string[] categories = Configuration.GetCategories();
            string[] options = Configuration.GetOptions();
            Storage[] storages = Configuration.GetStorages();

            while (true)
            {
                try
                {                    
                    Console.Write("Enter how many GB data do you want to transfer: ");
                    string data = Console.ReadLine().Trim();

                    if (Verify.IsInputNotPositiveNumber(data))
                        throw new InvalidOperationException("GB must be more than 0.");
                    Console.Clear();

                    DialogResult answer = Question.GetAnswerAboutEncoding();
                    if (answer == DialogResult.Yes)
                        TransferHelper.AddOverheadForEncoding(ref data);

                    while (true)
                    {
                        Configuration.Print(categories);
                        Console.Write("Enter which one do you want to transfer data: ");
                        string option = Console.ReadLine();

                        while (Verify.IsInputNotPositiveNumber(option) || Verify.IsOptionNotCorrect(int.Parse(option), categories.Length))
                        {
                            Console.WriteLine();
                            Console.Write("Enter one of this numbers (1, 2, 3, 4) : ");
                            option = Console.ReadLine();
                        }

                        int choice = int.Parse(option);
                        Console.Clear();

                        if (choice == (int)Drive.CategoryMenu.EXIT)
                        {
                            MessageBox.Show("See you next time goodbye.", "Transformer Coo inc ©", MessageBoxButtons.OK);
                            break;
                        }

                        int operation;
                        while (true)
                        {
                            Configuration.Print(options);
                            Console.Write("Enter which operation do you want to do: ");
                            option = Console.ReadLine();

                            while (Verify.IsInputNotPositiveNumber(option) || Verify.IsOptionNotCorrect(int.Parse(option), options.Length))
                            {
                                Console.WriteLine();
                                Console.Write("Enter one of this numbers (1, 2, 3, 4) : ");
                                option = Console.ReadLine();
                            }

                            Console.Clear();
                            operation = int.Parse(option);

                            if (operation == (int)Drive.Operations.BACK)
                                break;

                            switch (operation)
                            {
                                case (int)Drive.Operations.TRANSFER_RIGHT_NOW:
                                    {
                                        TransferHelper.TransferringPause();
                                        Console.Clear();
                                        storages[choice - 1].Copy(data);
                                    }
                                    break;
                                case (int)Drive.Operations.SHOW_HOW_MANY_MINUTES_TAKE:
                                    {
                                        storages[choice - 1].HowLongTakeToTransferData(data);
                                    }
                                    break;
                                case (int)Drive.Operations.SHOW_DRIVE_INFORMATION:
                                    {
                                        storages[choice - 1].PrintDeviceInformation();
                                    }
                                    break;
                            }

                            Console.Write("\nPress \"Enter\" key to continue");
                            Console.ReadLine();
                            Console.Clear();

                            if (operation == (int)Drive.Operations.TRANSFER_RIGHT_NOW)
                                break;

                        }

                        if (operation == (int)Drive.Operations.TRANSFER_RIGHT_NOW)
                        {
                            Console.Clear();
                            MessageBox.Show("See you soon, thank you for choosing us.", "Transformer Coo inc ©", MessageBoxButtons.OK);
                            break;
                        }
                    }
                }
                catch (InvalidOperationException caption)
                {
                    Console.Clear();
                    MessageBox.Show(caption.Message, "Transformer Coo inc ©", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Console.Clear();
            }
        }
    }
}