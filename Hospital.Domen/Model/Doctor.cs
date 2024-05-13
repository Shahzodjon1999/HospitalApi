using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Doctor : Person
{
	public string Positions { get; set; } = string.Empty;

	[JsonIgnore]
	public Department? Department { get; set; }

    [JsonIgnore]
    public Guid DepartmentId { get; set; }

    public List<Appointment>? Appointments { get; set; }
}
