using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record BranchRequest : EntityBaseRequest
{
    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

	public Guid HospitalID { get; set; }
}
