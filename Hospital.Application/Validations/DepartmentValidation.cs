using FluentValidation;
using Hospital.Application.RequestModel;

namespace Hospital.Application.Validations;

public class DepartmentValidation:AbstractValidator<DepartmentRequest>
{
    public DepartmentValidation()
    {
        RuleFor(n => n.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(12).WithMessage("You must be correct Name Length min 3 and Max 12");
        RuleFor(i=>i.BranchID).NotEmpty().NotNull().Must(id=>id !=Guid.Empty).WithMessage("BranchID must have value"); ;
    }
}
