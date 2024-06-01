using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Doctor : Person
{
    public string? Image { get; set; }
    public string Information { get; set; } = string.Empty;

    [JsonIgnore]
	public Department? Department { get; set; }

    [JsonIgnore]
    public Guid DepartmentId { get; set; }

    public string Position { get; set; } = string.Empty;
    public List<Appointment>? Appointments { get; set; }
}
