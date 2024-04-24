using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class WorkerValidation:AbstractValidator<WorkerRequest>
{
    public WorkerValidation()
    {
        RuleFor(w => w.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .NotEqual("string").WithMessage("You can not add string")
            .NotNull().WithMessage("First name cannot be null.")
            .MinimumLength(3).WithMessage("First name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(w => w.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .NotNull().WithMessage("Last name cannot be null.")
            .NotEqual("string").WithMessage("You can not add string")
            .MinimumLength(3).WithMessage("Last name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(w => w.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .NotNull().WithMessage("Phone number cannot be null.")
            .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage("Invalid phone number format.");

        RuleFor(w => w.Address)
            .NotEmpty().WithMessage("Address is required.")
            .NotNull().WithMessage("Address cannot be null.")
            .NotEqual("string").WithMessage("You can not add string")
            .MinimumLength(3).WithMessage("Address must be at least 3 characters.")
            .MaximumLength(100).WithMessage("Address cannot exceed 100 characters.");

        RuleFor(w => w.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .Must(BeAValidDate).WithMessage("Invalid date of birth.");

        RuleFor(w => w.DateRegister)
            .NotEmpty().WithMessage("Date of registration is required.")
            .Must(BeAValidDate).WithMessage("Invalid date of registration.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
