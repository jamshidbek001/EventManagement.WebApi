using EventManagement.Service.Dtos.EventTickets;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.EventTickets
{
    public class EventTicketCreateValidator : AbstractValidator<EventTicketCreateDto>
    {
        public EventTicketCreateValidator()
        {
            RuleFor(dto => dto.TicketName).NotNull().NotEmpty().WithMessage("Event ticket name is required")
                .MinimumLength(3).WithMessage("Event ticket name must be more than 3 characters")
                .MaximumLength(50).WithMessage("Event ticket name must be less than 50 characters");

            RuleFor(dto => dto.Price).NotNull().NotEmpty().WithMessage("Event ticket price is required");
            RuleFor(dto => dto.QuantityAvailable).NotNull().NotEmpty().WithMessage("Event ticket quantity is required");
            RuleFor(dto => dto.SaleStartDate).NotNull().NotEmpty().WithMessage("Event ticket sale start date is required");
            RuleFor(dto => dto.SaleEndDate).NotNull().NotEmpty().WithMessage("Event ticket sale end date is required");
        }
    }
}