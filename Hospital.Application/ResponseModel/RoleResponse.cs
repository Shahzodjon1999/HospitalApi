using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record RoleResponse:EntityBaseResponse
{
    public string Name { get; set; } = string.Empty;

    public bool Status { get; set; }
}
