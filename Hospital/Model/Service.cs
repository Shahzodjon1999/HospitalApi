using Hospital.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Models;

public class Service:EntityBase
{
	public string Name { get; set; } = string.Empty;

	public double Amount { get; set; }

	public int Count_Day { get; set; }
}
