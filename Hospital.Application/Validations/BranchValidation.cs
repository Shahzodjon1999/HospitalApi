using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class BranchValidation:AbstractValidator<BranchRequest>
{
    public BranchValidation()
    {
        RuleFor(n => n.Name).NotEmpty().NotNull().NotEqual("string").MinimumLength(3).MaximumLength(12).WithMessage("You must be write Name!!!");
        RuleFor(x => x.Location).NotNull().NotEmpty().MinimumLength(3).MaximumLength(12).WithMessage("You must be write Location!!!");
        RuleFor(x => x.HospitalID).Must(t => t != Guid.Empty).WithMessage("HospitalId must have value");
    }
}
