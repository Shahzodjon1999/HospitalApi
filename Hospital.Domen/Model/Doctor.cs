using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Doctor : Person
{
	public string Positions { get; set; } = string.Empty;

	public Department? Department { get; set; }
	public Guid DepartmentId { get; set; }

	public List<DoctorPatient>? DoctorPatients { get; set; }
}
