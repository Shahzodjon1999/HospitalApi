using Hospital.Abstract;

namespace Hospital.Models;

public class Services:EntityBase
{
	public string Name { get; set; } = string.Empty;

	public double Amount { get; set; }
}
