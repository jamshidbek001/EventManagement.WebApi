using EventManagement.Service.Dtos.Events;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.Events;

public class EventUpdateValidator : AbstractValidator<EventUpdateDto>
{
    public EventUpdateValidator()
    {
        RuleFor(dto => dto.EventName).NotNull().NotEmpty().WithMessage("Event name field is required")
            .MinimumLength(3).WithMessage("Event namae must be more than 3 characters")
            .MaximumLength(50).WithMessage("Event name must be less than 50 characters");

        RuleFor(dto => dto.Location).NotNull().NotEmpty().WithMessage("Location field is required");

        RuleFor(dto => dto.Description).NotEmpty().NotNull().WithMessage("Description field is required")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");
    }
}