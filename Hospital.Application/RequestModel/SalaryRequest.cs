using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record SalaryRequest:EntityBaseRequest
{
    public double Amount { get; set; }

    public double Bonus { get; set; }

    public Guid WorkerId { get; set; }
}
