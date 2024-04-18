using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public class DepartmentUpdateRequest : EntityBaseUpdateRequest
{
    public Guid BranchId { get; set; }
    public string Name { get; set; } = string.Empty;
}
