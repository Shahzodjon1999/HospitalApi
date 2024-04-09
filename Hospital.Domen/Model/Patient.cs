using Hospital.Domen.Abstract;
using Hospital.Domen.Enam;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Patient : Person
{
	public string Disease { get; set; } = string.Empty;

	public PatientStatus State { get; set; }
    [JsonIgnore]
    public Room? Room { get; set; }
    [JsonIgnore]
    public Guid RoomID { get; set; }
    [JsonIgnore]
    public List<DoctorPatient>? DoctorPatients { get; set; }
    [JsonIgnore]
    public List<DepartmentPatient>? DepartmentPatients { get; set; }
}
