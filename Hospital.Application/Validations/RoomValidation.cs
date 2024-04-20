using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class RoomValidation:AbstractValidator<RoomRequest>
{
    public RoomValidation()
    {
        RuleFor(x => x.RoomNumber)
          .NotEmpty().WithMessage("Floor number is required.")
          .GreaterThan(0).WithMessage("Floor number must be greater than 0.");
        RuleFor(p => p.FloorId)
           .NotEmpty().WithMessage("Room ID is required.")
           .NotEqual(Guid.Empty).WithMessage("Room ID must have a value.");
    }
}
