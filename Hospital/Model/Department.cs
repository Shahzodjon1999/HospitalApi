using Hospital.Api.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Api.Model
{
	public class Department:EntityBase
	{
		public string Name { get; set; }=string.Empty;

		public Branch? Branch { get; set; }

		public Guid BranchID { get; set; }

		[JsonIgnore]
		public List<Doctor>? Doctors { get; set; }

		public List<DepartmentPatient>? DepartmentPatients { get; set; }
	}
}
