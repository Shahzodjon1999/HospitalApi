using Hospital.Abstract;
using Hospital.Models;
using System.Text.Json.Serialization;

namespace Hospital.Model;

public class Salary:EntityBase
{
	public double Amount { get; set; }

	public double Bonus { get; set; }
}
