using Hospital.Api.Entity;
using Hospital.Api.Model;
using System.Text.Json.Serialization;

namespace Hospital.Api.ResponseModel
{
	public class DepartmentResponse:EntityBaseResponse
	{
		public string Name { get; set; } = string.Empty;

		public Guid BranchID { get; set; }

		[JsonIgnore]
		public List<Doctor>? Doctors { get; set; }

		public List<DepartmentPatient>? DepartmentPatients { get; set; }
	}
}
