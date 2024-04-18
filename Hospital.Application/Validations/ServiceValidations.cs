using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validation;

public class ServiceValidations:AbstractValidator<HospitalRequest>
{
    public ServiceValidations()
    {
        RuleFor(a => a.Name).NotEmpty().NotNull().MinimumLength(3).NotEqual("string");
        RuleFor(a => a.Location).NotEmpty().NotNull().MinimumLength(3).NotEqual("string");
    }
}
