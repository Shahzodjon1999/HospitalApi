using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class SalaryValidation:AbstractValidator<SalaryRequest>
{
    public SalaryValidation()
    {
        RuleFor(s => s.Amount)
             .NotEmpty().WithMessage("Amount is required.")
             .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(s => s.Bonus)
            .NotEmpty().WithMessage("Bonus is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Bonus must be greater than or equal to 0.");

        RuleFor(s => s.WorkerId)
            .NotEmpty().WithMessage("Worker ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Worker ID must have a value.");
    }
}
