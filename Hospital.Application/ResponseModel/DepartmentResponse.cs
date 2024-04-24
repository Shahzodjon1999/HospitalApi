using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.ResponseModel;

public record DepartmentResponse:EntityBaseResponse
{
	public string  BranchName { get; set; }=string.Empty;
	public string Name { get; set; } = string.Empty;
	//public List<Doctor>? Doctors { get; set; }
	//this is not good way You must be don't use List<T> in the DTO
}
