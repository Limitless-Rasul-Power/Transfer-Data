using System.Windows.Forms;

namespace Backup_Practice
{
    public static class Question
    {
        public static DialogResult GetAnswerAboutEncoding()
        {
            DialogResult buttonForEncoding = 
                MessageBox.Show("Do you want to transfer data via TCP protocol?\n(TCP protocol means your data encodes for safe transfer)",
                                "Transformer Coo.",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            return buttonForEncoding;
        }
    }
}
