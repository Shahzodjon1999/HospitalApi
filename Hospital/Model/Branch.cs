using Hospital.Abstract;
using Hospital.Api.Model;
using Hospital.Model;
using System.Text.Json.Serialization;

namespace Hospital.Models;

public class Branch:EntityBase
{
	public string Location { get; set; } = string.Empty;

	public HospitalModel? HospitalModel { get; set; }

	public Guid HospitalID { get; set; }

	[JsonIgnore]
	public List<Department>? Departments { get; set; }
}
