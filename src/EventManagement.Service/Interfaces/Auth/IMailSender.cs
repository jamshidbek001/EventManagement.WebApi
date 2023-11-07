using EventManagement.Service.Dtos.Auth;

namespace EventManagement.Service.Interfaces.Auth
{
    public interface IMailSender
    {
        public Task<bool> SendEmailAsync(EmailMessage message);
    }
}