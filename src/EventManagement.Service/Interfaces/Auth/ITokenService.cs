using EventManagement.Domain.Entities.Users;

namespace EventManagement.Service.Interfaces.Auth
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}