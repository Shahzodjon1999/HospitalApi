using Hospital.Abstract;
using Hospital.Models;

namespace Hospital.Model;

public class Salary:EntityBase
{
	public double Amount { get; set; }

	public double Bonus { get; set; }

	public Worker? Worker { get; set; }

	public Guid WorkerId { get; set; }

	public DateTime DateSave { get; set; }
}
