using EventManagement.Service.Dtos.EventRegistrations;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.EventRegistrations
{
    public class EventRegistrationCreateValidator : AbstractValidator<EventRegistrationCreateDto>
    {
        public EventRegistrationCreateValidator()
        {
            RuleFor(dto => dto.EventId).NotEmpty().NotNull().WithMessage("Event id is required");
            RuleFor(dto => dto.AttendeeId).NotEmpty().NotNull().WithMessage("Attendee id is required");
            RuleFor(dto => dto.TotalPrice).NotNull().NotEmpty().WithMessage("Total price is required");
            RuleFor(dto => dto.NumberOfTickets).NotNull().NotEmpty().WithMessage("Number of tickets is required");
        }
    }
}