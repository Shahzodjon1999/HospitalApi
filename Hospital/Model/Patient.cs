using Hospital.Abstract;
using Hospital.Enam;
using System.Collections.Generic;

namespace Hospital.Models;

public class Patient:Person
{
	public string DiseaseName { get; set; } = string.Empty;

	public List<Doctor>? Doctors { get; set; }

	public Gender Gender { get; set; }

	public int FloorNumber { get; set; }

	public int RoomNumber { get; set; }

	public PatientStatus State { get; set; }
}
