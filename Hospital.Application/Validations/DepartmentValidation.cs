using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class DepartmentValidation:AbstractValidator<DepartmentRequest>
{
    public DepartmentValidation()
    {
        RuleFor(d => d.Name)
             .NotEmpty().WithMessage("Name is required.")
             .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(d => d.BranchID)
            .NotEmpty().WithMessage("Branch ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Branch ID must have a value.");
    }
}
