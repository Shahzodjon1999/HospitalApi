using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Salary:EntityBase
{
	public double Amount { get; set; }

    public Worker? Worker { get; set; }
	public Guid WorkerId { get; set; }
	public double Bonus { get; set; }
}
