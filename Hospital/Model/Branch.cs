using Hospital.Abstract;
using System.Collections.Generic;

namespace Hospital.Models;

public class Branch:EntityBase
{
   public Branch()
   {
		Workers = new();
		Patients= new();
   }

	public string Address { get; set; } = string.Empty;

	public List<Patient>? Patients { get; set; }

	public List<Worker>? Workers { get; set; }
}
