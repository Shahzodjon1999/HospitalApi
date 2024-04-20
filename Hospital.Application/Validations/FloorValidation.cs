using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class FloorValidation:AbstractValidator<FloorRequest>
{
    public FloorValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name cannot be null.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

        RuleFor(x => x.FloorNumber)
            .NotEmpty().WithMessage("Floor number is required.")
            .GreaterThan(0).WithMessage("Floor number must be greater than 0.");
    }
}
