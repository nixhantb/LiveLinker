using FluentValidation;
using LiveLinker.Events.LiveLinker.Events.Core.Entities;

namespace LiveLinker.Events.LiveLinker.Events.Validators
{

    public class EventsValidator : AbstractValidator<Event>
    {

        public EventsValidator()
        {

            RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title Cannot exeed 100 characters");

            RuleFor(e => e.Date)
            .GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Event date must be in the future.");

            RuleFor(e => e.DurationInMinutes)
                .GreaterThan(0).WithMessage("Duration must be greater than 0 minutes.");

            RuleFor(e => e.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(250).WithMessage("Location cannot exceed 250 characters.");

            RuleFor(e => e.OrganizerId)
                .NotEmpty().WithMessage("OrganizerId is required.");

            RuleFor(e => e.Status)
                .IsInEnum().WithMessage("Invalid status value.");

            RuleFor(e => e.TicketPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Ticket price must be greater than or equal to 0.")
                .When(e => e.TicketPrice.HasValue);

            RuleFor(e => e.MaxAttendees)
                .GreaterThan(0).WithMessage("MaxAttendees must be greater than 0.")
                .When(e => e.MaxAttendees.HasValue);

            RuleForEach(e => e.Tags)
                .NotEmpty().WithMessage("Tags cannot contain empty values.")
                .MaximumLength(50).WithMessage("Each tag cannot exceed 50 characters.");

        }
    }
}