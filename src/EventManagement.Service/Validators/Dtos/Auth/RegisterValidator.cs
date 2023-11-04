using EventManagement.Service.Dtos.Auth;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.Auth
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("Firstname is required")
            .MaximumLength(30).WithMessage("Firstname must be less than 30 characters");

            RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("Lastname is required")
                .MaximumLength(30).WithMessage("Lastname must be less than 30 characters");

            RuleFor(dto => dto.Email).NotNull().NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address");

            RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
                .WithMessage("Password is not strong");
        }
    }
}