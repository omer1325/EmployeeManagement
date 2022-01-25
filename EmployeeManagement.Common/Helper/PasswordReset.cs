using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.Helper
{
    public class PasswordReset
    {
        public static void PasswordResetSendEmail(string link, string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("mjasonmadison@gmail.com");
            mail.To.Add(email);

            mail.Subject = $"Employee Management::Şifre sıfırlama";
            mail.Body = "<h2>Şifrenizi yenilemek için lütfen aşağıdaki linke tıklayınız.</h2><hr/>";
            mail.Body += $"<a href='{link}'>Şifre sıfırlama linki.</a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("mjasonmadison@gmail.com", "123madison");

            smtpClient.Send(mail);
        }
    }
}
