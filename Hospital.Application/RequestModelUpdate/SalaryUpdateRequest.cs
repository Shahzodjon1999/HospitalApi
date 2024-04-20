using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public record SalaryUpdateRequest: EntityBaseUpdateRequest
{
    public double Amount { get; set; }

    public double Bonus { get; set; }

    public Guid WorkerId { get; set; }
}
