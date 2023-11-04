using EventManagement.Service.Dtos.Comments;
using FluentValidation;

namespace EventManagement.Service.Validators.Dtos.Comments
{
    public class CommentUpdateValidator : AbstractValidator<CommentUpdateDto>
    {
        public CommentUpdateValidator()
        {
            RuleFor(dto => dto.EventId).NotNull().NotEmpty().WithMessage("Comment event id is required");
            RuleFor(dto => dto.AuthorId).NotEmpty().NotNull().WithMessage("Comment author id is required");

            RuleFor(dto => dto.Content).NotNull().NotEmpty().WithMessage("Content is required")
                .MinimumLength(3).WithMessage("Content must be more than 3 characters")
                .MaximumLength(50).WithMessage("Content must be less than 50 characters");

            RuleFor(dto => dto.Timestamp).NotNull().NotEmpty().WithMessage("Time stamp is required");
        }
    }
}