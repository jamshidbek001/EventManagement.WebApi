using EventManagement.Service.Common.Helpers;
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

            //int maxImageSize = 3;
            //RuleFor(dto => dto.Image).NotNull().NotEmpty().WithMessage("Image field is required");

            //RuleFor(dto => dto.Image.Length).LessThan(maxImageSize * 1024 * 1024 + 1)
            //    .WithMessage($"Image size must be less than {maxImageSize}");

            //RuleFor(dto => dto.Image.FileName).Must(predicate =>
            //{
            //    FileInfo fielinfo = new FileInfo(predicate);
            //    return MediaHelper.GetImageExtensions().Contains(fielinfo.Extension);
            //}).WithMessage("This file type is not image file");
        }
    }
}