using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class AppointmentValidation : AbstractValidator<AppointmentRequest>
{
    public AppointmentValidation()
    {
        RuleFor(a => a.Name)
             .NotEmpty().WithMessage("Name is required.")
             .NotNull().WithMessage("Name cannot be null.")
             .NotEqual("string").WithMessage("You can not add string")
             .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
             .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(w => w.AppointmentDate)
          .NotEmpty().WithMessage("Date of birth is required.")
          .Must(BeAValidDate).WithMessage("Invalid date of birth.");

        RuleFor(b => b.DoctorId)
            .NotEmpty().WithMessage("Hospital ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Hospital ID must have a value.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
