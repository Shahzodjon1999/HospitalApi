using Hospital.Abstract;
using Hospital.Enam;
using Hospital.Model;

namespace Hospital.Models;

public class Doctor:Person
{
	public string Positions { get; set;} = string.Empty;

	public Gender Gender { get; set; }

	public Branch Branch { get; set; }

	public Guid BranchId { get; set; }

	public HospitalModel HospitalModel { get; set; }

	public Guid HospitalId { get; set; }

	public DateTime DateSave { get; set; }
}
