using Hospital.Abstract;
using Hospital.Models;
using System.Collections.Generic;

namespace Hospital.Model;

public class HospitalModel:EntityBase
{
    public HospitalModel()
    {
        Doctors = new();
		Branches = new();
        Patients = new();
    }

    public string Name { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

	public List<Doctor> Doctors { get; set; }

    public List<Patient>? Patients { get; set; }

	public List<Branch> Branches { get; set; }
}
