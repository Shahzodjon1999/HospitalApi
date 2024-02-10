using Hospital.Abstract;
using Hospital.Model;
namespace Hospital.Models;

public class Worker:Person
{
	public string Role { get; set; } = string.Empty;

	public string Name { get; set; } = string.Empty;

	public Salary? Salary { get; set; }

	public Service? Service { get; set; }

	public DateTime DateSave { get; set; }
}
