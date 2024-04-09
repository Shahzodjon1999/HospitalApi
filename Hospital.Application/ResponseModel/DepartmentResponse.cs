using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel;

public class DepartmentResponse:EntityBaseResponse
{
	public string Name { get; set; } = string.Empty;

	public Guid BranchID { get; set; }

	[JsonIgnore]
	public List<Doctor>? Doctors { get; set; }
    [JsonIgnore]
    public List<DepartmentPatient>? DepartmentPatients { get; set; }
}
