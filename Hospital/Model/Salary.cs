using Hospital.Abstract;

namespace Hospital.Model;

public class Salary:EntityBase
{
	public double Amount { get; set; }

    public ulong WorkerId { get; set; }

	public double Bonus { get; set; }
}
