using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class DoctorValidation : AbstractValidator<DoctorRequest>
{
    public DoctorValidation()
    {
        RuleFor(n => n.FirstName)
           .NotEmpty().WithMessage("First name is required.")
           .NotEqual("string").WithMessage("You can not add string")
           .NotNull().WithMessage("First name cannot be null.")
           .MinimumLength(3).WithMessage("First name must be at least 3 characters.")
           .MaximumLength(12).WithMessage("First name cannot exceed 12 characters.");

        RuleFor(n => n.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .NotEqual("string").WithMessage("You can not add string")
            .NotNull().WithMessage("Last name cannot be null.")
            .MinimumLength(3).WithMessage("Last name must be at least 3 characters.")
            .MaximumLength(12).WithMessage("Last name cannot exceed 12 characters.");

        RuleFor(n => n.Address)
            .NotEmpty().WithMessage("Address is required.")
            .NotEqual("string").WithMessage("You can not add string")
            .NotNull().WithMessage("Address cannot be null.")
            .MinimumLength(3).WithMessage("Address must be at least 3 characters.")
            .MaximumLength(12).WithMessage("Address cannot exceed 12 characters.");

        RuleFor(n => n.Positions)
            .NotEmpty().WithMessage("Position is required.")
            .NotNull().WithMessage("Position cannot be null.")
            .NotEqual("string").WithMessage("You can not add string")
            .MinimumLength(3).WithMessage("Position must be at least 3 characters.")
            .MaximumLength(12).WithMessage("Position cannot exceed 12 characters.");

        RuleFor(n => n.DepartmentId)
            .NotEmpty().WithMessage("Department ID is required.")
            .NotNull().WithMessage("Department ID cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("Department ID must have a value.");

        RuleFor(n => n.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .NotNull().WithMessage("Phone number cannot be null.")
            .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage("Invalid phone number format.");

        RuleFor(n => n.DateRegister)
            .NotEmpty().WithMessage("Date and time are required.")
            .NotNull().WithMessage("Date and time cannot be null.")
            .Must(BeAValidDate).WithMessage("Invalid date and time format.");
        RuleFor(n => n.DateOfBirth)
           .NotEmpty().WithMessage("Date and time are required.")
           .NotNull().WithMessage("Date and time cannot be null.")
           .Must(BeAValidDate).WithMessage("Invalid date and time format.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
