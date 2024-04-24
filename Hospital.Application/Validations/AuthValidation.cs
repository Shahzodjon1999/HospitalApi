using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class AuthValidation:AbstractValidator<AuthRequest>
{
    public AuthValidation()
    {
        RuleFor(u => u.Login)
            .NotEmpty().WithMessage("Login is required.")
            .NotNull().WithMessage("Login cannot be null.")
            .NotEqual("string").WithMessage("You can not add string")
            .MinimumLength(3).WithMessage("Login must be at least 3 characters.")
            .MaximumLength(50).WithMessage("Login cannot exceed 50 characters.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required.")
            .NotNull().WithMessage("Password cannot be null.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
            .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");

        RuleFor(u => u.IsBlocked)
            .NotNull().WithMessage("IsBlocked cannot be null.")
            .Equal(true).WithMessage("IsBlocked must be true by default.");

        RuleFor(p => p.WorkerId)
            .NotEmpty().WithMessage("Room ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Room ID must have a value.");
    }
}
