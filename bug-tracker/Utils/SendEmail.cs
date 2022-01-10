
using System.Collections.Generic;
using System.IO;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace bug_tracker.Utils
{
    public static class SendEmail
    {
        public static void send(string toEmail, string subject, string emailTemplate, Dictionary<string, string> templateBindings)
        {
            string text = File.ReadAllText("EmailTemplates/" + emailTemplate + ".html");

            foreach (KeyValuePair<string, string> kvp in templateBindings)
            {
                text = text.Replace("#" + kvp.Key + "#", kvp.Value);
            }

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mai.bug.tracker@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = text };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mai.bug.tracker@gmail.com", "naoiaporasenhaaquine");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}