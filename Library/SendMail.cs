using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class SendMail
    {
        public static void SendEmail(string senderEmail, string senderPassword, string recipientEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            var mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);
            mailMessage.IsBodyHtml = true;

            smtpClient.Send(mailMessage);
        }

    }
}
