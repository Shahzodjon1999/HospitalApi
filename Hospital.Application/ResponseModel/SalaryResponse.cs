using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record SalaryResponse:EntityBaseResponse
{
    public double Amount { get; set; }

    public string? WorkerName { get; set; }

    public double Bonus { get; set; }
}
