using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class BranchValidation:AbstractValidator<BranchRequest>
{
    public BranchValidation()
    {
        RuleFor(b => b.Name)
              .NotEmpty().WithMessage("Name is required.")
              .NotEqual("string").WithMessage("You can not add string")
              .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(b => b.Location)
            .NotEqual("string").WithMessage("You can not add string")
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(100).WithMessage("Location cannot exceed 100 characters.");

        RuleFor(b => b.HospitalID)
            .NotEmpty().WithMessage("Hospital ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Hospital ID must have a value.");
    }
}
