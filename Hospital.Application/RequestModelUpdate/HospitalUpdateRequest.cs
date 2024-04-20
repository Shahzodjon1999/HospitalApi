using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public record HospitalUpdateRequest:EntityBaseUpdateRequest
{
    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
}
