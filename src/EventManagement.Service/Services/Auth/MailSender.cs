using EventManagement.Service.Dtos.Auth;
using EventManagement.Service.Interfaces.Auth;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EventManagement.Service.Services.Auth
{
    public class MailSender : IMailSender
    {
        private readonly string _email = "jamshidbekjames@gmail.com";
        private readonly string _password = "ckpafgfgcfzvaiuc";
        public async Task<bool> SendEmailAsync(EmailMessage message)
        {
            try
            {
                var mail = new MimeMessage();
                mail.From.Add(MailboxAddress.Parse(_email));
                mail.To.Add(MailboxAddress.Parse(message.Recipient));
                mail.Subject = message.Title;
                mail.Body = new TextPart(TextFormat.Html) { Text = message.Content };

                using (var smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_email, _password);
                    await smtp.SendAsync(mail);
                    await smtp.DisconnectAsync(true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}