using EventManagement.Domain.Entities;

namespace EventManagement.DataAccess.ViewModels.Users;

public class UserViewModel : Auditable
{
    public string UserName { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}