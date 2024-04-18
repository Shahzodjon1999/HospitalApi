namespace Hospital.Domen.Model;

public class Salary
{
    public Guid Id { get; set; }

	public double Amount { get; set; }

    public List<Worker>? Workers { get; set; }

	public double Bonus { get; set; }
}
