using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record DepartmentResponse:EntityBaseResponse
{
	public string  BranchName { get; set; }=string.Empty;
	public string Name { get; set; } = string.Empty;
}
