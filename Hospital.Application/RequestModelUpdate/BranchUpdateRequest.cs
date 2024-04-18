using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public class BranchUpdateRequest : EntityBaseUpdateRequest
{
    public Guid HospitalId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}
