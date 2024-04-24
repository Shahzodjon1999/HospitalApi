using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class RoleValidation:AbstractValidator<RoleRequest>
{
    public RoleValidation()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotEqual("string").WithMessage("You can not add string")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(r => r.Status)
            .NotNull().WithMessage("Status cannot be null.");

        RuleFor(r => r.WorkerId)
            .NotEmpty().WithMessage("Worker ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Worker ID must have a value.");
    }
}
