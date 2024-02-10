 using Hospital.Abstract;
using Hospital.Api.Model;
using Hospital.Models;

namespace Hospital.Model;

public class HospitalModel:EntityBase
{
	public string Name { get; set; } = string.Empty;

	public string Location { get; set; } = string.Empty;

	public List<Branch>? Branches { get; set; }
}
