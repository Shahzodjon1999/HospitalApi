using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class AppointmentValidation : AbstractValidator<HospitalRequest>
{
    public AppointmentValidation()
    {
        RuleFor(a => a.Name)
             .NotEmpty().WithMessage("Name is required.")
             .NotNull().WithMessage("Name cannot be null.")
             .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
             .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(a => a.Location)
            .NotEmpty().WithMessage("Location is required.")
            .NotNull().WithMessage("Location cannot be null.")
            .MinimumLength(3).WithMessage("Location must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Location cannot exceed 50 characters.");
    }
}
