using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class AppointmentValidation : AbstractValidator<HospitalRequest>
{
    public AppointmentValidation()
    {
        RuleFor(a => a.Name).NotEmpty().NotNull().MinimumLength(3).NotEqual("string");
        RuleFor(a => a.Location).NotEmpty().NotNull().MinimumLength(3).NotEqual("string");
    }
}
