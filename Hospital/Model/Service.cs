using Hospital.Abstract;

namespace Hospital.Models;

public class Service:EntityBase
{
	public string Name { get; set; } = string.Empty;

	public double Amount { get; set; }

	public int Count_Day { get; set; }

	public List<Worker>? Workers { get; set; }

	public DateTime DateSave { get; set; }
}
