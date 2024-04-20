using Hospital.Domen.Abstract;
namespace Hospital.Domen.Model;

public class Worker : Person
{
	public Salary? Salary { get; set; }
	public Auth? Auth { get; set; }
}
