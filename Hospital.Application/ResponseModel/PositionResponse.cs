using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record PositionResponse : EntityBaseResponse
{
    public string Name { get; set; } = string.Empty;
}
