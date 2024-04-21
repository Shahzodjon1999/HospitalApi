using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public record RoleUpdateRequest:EntityBaseUpdateRequest
{
    public string Name { get; set; } = string.Empty;

    public bool Status { get; set; }

    public Guid WorkerId { get; set; }
}
