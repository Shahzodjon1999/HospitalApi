using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.UpdateRequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class SalaryMap
{
    public static Salary MapToSalary(this SalaryRequest request)
    {
        return new Salary()
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Bonus = request.Bonus,
        };
    }
    public static Salary MapToSalaryUpdate(this SalaryUpdateRequest request)
    {
        return new Salary()
        {
            Id = request.Id,
            Amount = request.Amount,
            Bonus = request.Bonus,
        };
    }

    public static SalaryResponse MapToSalaryResponse(this Salary salary)
    {
        return new SalaryResponse()
        {
           Id=salary.Id,
           Bonus=salary.Bonus,
           Amount=salary.Amount,
           WorkerName = salary.Worker.FirstName
        };
    }
}
