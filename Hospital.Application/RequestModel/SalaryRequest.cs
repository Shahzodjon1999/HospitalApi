using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.RequestModel;

public record SalaryRequest:EntityBaseRequest
{
    public double Amount { get; set; }

    public double Bonus { get; set; }

    public Guid WorkId { get; set; }
}
