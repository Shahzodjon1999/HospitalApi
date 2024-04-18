using Hospital.Domen.Abstract;
namespace Hospital.Domen.Model;

public class Worker : Person
{
	public Salary? Salary { get; set; }
	public Guid SalaryId { get; set; }

	public User? User { get; set; }

	public Guid UserId { get; set; }

	public string Role { get; set; } = string.Empty;
}
