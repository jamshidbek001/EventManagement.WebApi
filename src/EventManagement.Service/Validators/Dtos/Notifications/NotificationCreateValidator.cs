using EventManagement.Service.Dtos.Notifications;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.Notifications
{
    public class NotificationCreateValidator : AbstractValidator<NotificationCreateDto>
    {
        public NotificationCreateValidator()
        {
            RuleFor(dto => dto.RecipientId).NotNull().NotEmpty().WithMessage("Recipient id is required");
            RuleFor(dto => dto.Content).NotNull().NotEmpty().WithMessage("Content is required");
            RuleFor(dto => dto.Timestamp).NotNull().NotEmpty().WithMessage("Time stamp is required");
        }
    }
}