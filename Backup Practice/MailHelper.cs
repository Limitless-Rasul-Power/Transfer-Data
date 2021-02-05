using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Network
{
    public static class MailHelper
    {
        public static readonly string MyEmail = "r.osmanl@mail.ru";
        public static void SendEmail(in string to, in string body)
        {
            try
            {
                string header = $"<h1 style = \"color:green;\"> SUCCESSFULL TRANSFORMATION </h1>";
                MailMessage message = new MailMessage(MyEmail, to, "Transformers Coo inc ©", header + body);
                message.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient($"smtp.mail.ru", 587);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("yourRealEmail", "yourRealpassword");
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }
            catch (Exception caption)
            {
                Console.Clear();
                MessageBox.Show(caption.Message, "Transformer Coo inc ©", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
    }
}
