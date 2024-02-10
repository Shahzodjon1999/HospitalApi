using Hospital.Abstract;
using Hospital.Enam;

namespace Hospital.Models;

public class Patient:Person
{
	public string Name { get; set; } = string.Empty;

	public Doctor? Doctor { get; set; }

	public Guid DoctorId { get; set; }
	
	public Gender Gender { get; set; }

	public Room? Room { get; set; }

	public PatientStatus State { get; set; }

	public DateTime DateSave { get; set; }
}
