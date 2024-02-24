using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class BranchRequest: EntityBaseRequest
{
	public string Location { get; set; } = string.Empty;

	public Guid HospitalID { get; set; }
}
