using Hospital.Domen.Abstract;
using Hospital.Domen.Enam;

namespace Hospital.Domen.Model;

public class Patient : Person
{
	public string Disease { get; set; } = string.Empty;

	public PatientStatus State { get; set; }

	public Room? Room { get; set; }
	public Guid RoomID { get; set; }

	public List<DoctorPatient>? DoctorPatients { get; set; }

	public List<DepartmentPatient>? DepartmentPatients { get; set; }
}
