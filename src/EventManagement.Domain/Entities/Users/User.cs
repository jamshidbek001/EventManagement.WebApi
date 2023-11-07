namespace EventManagement.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string UserName { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string PasswordHash { get; set; } = String.Empty;

        public string Salt { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        //public string ImagePath { get; set; } = String.Empty;
    }
}