using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class HospitalValidation:AbstractValidator<HospitalRequest>
{
    public HospitalValidation()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name cannot be null.")
            .NotEqual("string").WithMessage("You can not add string")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(a => a.Location)
            .NotEmpty().WithMessage("Location is required.")
            .NotNull().WithMessage("Location cannot be null.")
            .NotEqual("string").WithMessage("You can not add string")
            .MinimumLength(3).WithMessage("Location must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Location cannot exceed 50 characters.");
    }
}
