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

	public string Phone { get; set; }

	public int NumberOfDepartments { get; set; }

	public int NumberOfDoctors { get; set; }

	public int NumberOfBeds { get; set; }

	public List<Doctor> Doctors { get; set; }

    public List<Patient>? Patients { get; set; }

	public List<Branch> Branches { get; set; }

	/// <summary>
	/// If i want to create database i use this like 
	/// </summary>
	// Navigation properties
	//public virtual ICollection<Department> Departments { get; set; }
	//public virtual ICollection<Doctor> Doctors { get; set; }
}
