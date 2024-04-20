using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class PatientValidation:AbstractValidator<PatientRequest>
{
    public PatientValidation()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .NotNull().WithMessage("First name cannot be null.")
            .MinimumLength(3).WithMessage("First name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .NotNull().WithMessage("Last name cannot be null.")
            .MinimumLength(3).WithMessage("Last name must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(p => p.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .NotNull().WithMessage("Phone number cannot be null.")
            .Matches(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").WithMessage("Invalid phone number format.");

        RuleFor(p => p.Address)
            .NotEmpty().WithMessage("Address is required.")
            .NotNull().WithMessage("Address cannot be null.")
            .MinimumLength(3).WithMessage("Address must be at least 3 characters.")
            .MaximumLength(100).WithMessage("Address cannot exceed 100 characters.");

        RuleFor(p => p.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .Must(BeAValidDate).WithMessage("Invalid date of birth.");

        RuleFor(p => p.DateRegister)
            .NotEmpty().WithMessage("Date of registration is required.")
            .Must(BeAValidDate).WithMessage("Invalid date of registration.");

        RuleFor(p => p.Disease)
            .NotEmpty().WithMessage("Disease information is required.")
            .NotNull().WithMessage("Disease information cannot be null.")
            .MaximumLength(100).WithMessage("Disease information cannot exceed 100 characters.");

        RuleFor(p => p.State)
            .IsInEnum().WithMessage("Invalid patient status.");

        RuleFor(p => p.RoomId)
            .NotEmpty().WithMessage("Room ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Room ID must have a value.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
