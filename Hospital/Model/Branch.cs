using Hospital.Abstract;
using Hospital.Api.Model;
using Hospital.Model;

namespace Hospital.Models;

public class Branch:EntityBase
{
	public string Location { get; set; } = string.Empty;

	public HospitalModel? HospitalModel { get; set; }

	public Guid HospitalID { get; set; }

	public List<Department>? Departments { get; set; }
}
