using Hospital.Abstract;
using Hospital.Models;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Hospital.Model;

public class HospitalModel:EntityBase
{
	[BsonElement("name")]
	public string Name { get; set; } = string.Empty;

	[BsonElement("address")]
	public string Address { get; set; } = string.Empty;

	[BsonElement("phone")]
	public string Phone { get; set; }

	[BsonElement("name_of_departments")]
	public int NumberOfDepartments { get; set; }

	[BsonElement("name_of_doctors")]
	public int NumberOfDoctors { get; set; }

	[BsonElement("name_of_beds")]
	public int NumberOfBeds { get; set; }

	//public List<Doctor> Doctors { get; set; }

 //   public List<Patient>? Patients { get; set; }

	//public List<Branch> Branches { get; set; }

	/// <summary>
	/// If i want to create database i use this like 
	/// </summary>
	// Navigation properties
	//public virtual ICollection<Department> Departments { get; set; }
	//public virtual ICollection<Doctor> Doctors { get; set; }
}
