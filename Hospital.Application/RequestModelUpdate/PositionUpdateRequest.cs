using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public record PositionUpdateRequest : EntityBaseUpdateRequest
{
    public string Name { get; set; } = string.Empty;
}
