using Hospital.Api.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Api.Model;

public class Hospital : EntityBase
{
	public string Name { get; set; } = string.Empty;

	public string Location { get; set; } = string.Empty;

	[JsonIgnore]
	public List<Branch>? Branches { get; set; }
}
