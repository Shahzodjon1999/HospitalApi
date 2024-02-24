using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Branch : EntityBase
{
	public string Location { get; set; } = string.Empty;

	public Hospital? HospitalModel { get; set; }

	public Guid HospitalID { get; set; }

	[JsonIgnore]
	public List<Department>? Departments { get; set; }
}
