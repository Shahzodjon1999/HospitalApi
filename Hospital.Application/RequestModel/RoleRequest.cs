using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record RoleRequest : EntityBaseRequest
{
    public string Name { get; set; } = string.Empty;

    public bool Status { get; set; }
}
