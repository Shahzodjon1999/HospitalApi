using Hospital.Abstract;
using Hospital.Models;
using System.Text.Json.Serialization;

namespace Hospital.Model;

public class HospitalModel:EntityBase
{
	public string Name { get; set; } = string.Empty;

	public string Location { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Branch>? Branches { get; set; }
}
