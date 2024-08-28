using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public record FloorUpdateRequest:EntityBaseUpdateRequest
{
    public int FloorNumber { get; set; }
    public string Name { get; set; } = string.Empty;
}
