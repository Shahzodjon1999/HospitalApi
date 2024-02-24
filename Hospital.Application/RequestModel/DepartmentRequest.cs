using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class DepartmentRequest : EntityBaseRequest
{
	public string Name { get; set; } = string.Empty;

	public Guid BranchID { get; set; }
}
