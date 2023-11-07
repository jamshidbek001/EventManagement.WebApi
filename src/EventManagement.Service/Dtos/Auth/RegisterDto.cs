using Microsoft.AspNetCore.Http;

namespace EventManagement.Service.Dtos.Auth
{
    public class RegisterDto
    {
        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        //public IFormFile Image { get; set; } = default!;
    }
}