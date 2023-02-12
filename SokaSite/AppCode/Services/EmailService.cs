using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Soka.WebUI.AppCode.Services
{
    public class EmailService
    {
        private readonly EmailServiceOptions options;

        public EmailService(IOptions<EmailServiceOptions> options)
        {
            this.options = options.Value;
        }
        public async Task<bool> SendEmailAsync(string toEmail, string approveLink)
        {
            string fromEmail = options.UserName;
            SmtpClient smtpClient = new SmtpClient(options.SmtpHost, options.SmtpPort);
            smtpClient.Credentials = new NetworkCredential(fromEmail, options.Password);
            smtpClient.EnableSsl = true;

            MailAddress from = new MailAddress(fromEmail, options.DisplayName);
            MailAddress to = new MailAddress(toEmail);

            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = options.Subject;
            mailMessage.Body = "Memnun olduq,<br/>Zehmet olmasa abuneliyiniz  " +
                    $"<a href='{approveLink}'>link</a> tamamalayasiniz";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
            return true;
        }

    }
    public class EmailServiceOptions
    {
        public string DisplayName { get; set; }
        public string SmtpHost { get; set; }
        public string Subject { get; set; }
        public int SmtpPort { get; set; }
        public bool EnableSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
