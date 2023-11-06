using EventManagement.Service.Dtos.Auth;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.Auth
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
                .WithMessage("Password is not strong password");
        }
    }
}