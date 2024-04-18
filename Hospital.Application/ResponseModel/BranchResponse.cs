using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.ResponseModel;

public record BranchResponse : EntityBaseResponse
{
	public string HospitalName { get; set; }=string.Empty;
	public string Name { get; set; }=string.Empty;
	public string Location { get; set; } = string.Empty;

	public List<Department>? Departments { get; set; }
}
