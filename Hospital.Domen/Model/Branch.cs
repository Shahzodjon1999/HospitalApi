using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Branch : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
	[JsonIgnore]
	public Hospital? HospitalModel { get; set; }
	[JsonIgnore]
	public Guid HospitalID { get; set; }
	[JsonIgnore]
	public List<Department>? Departments { get; set; }
}
