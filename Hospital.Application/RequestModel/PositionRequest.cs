using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record PositionRequest : EntityBaseRequest
{
    public string Name { get; set; } = string.Empty;
}
