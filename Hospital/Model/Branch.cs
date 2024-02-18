using Hospital.Api.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Api.Model;

public class Branch : EntityBase
{
	public string Location { get; set; } = string.Empty;

	public Hospital? HospitalModel { get; set; }

	public Guid HospitalID { get; set; }

	[JsonIgnore]
	public List<Department>? Departments { get; set; }
}
