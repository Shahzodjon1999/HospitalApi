using Hospital.Abstract;
using Hospital.Api.Model;

namespace Hospital.Model;

public class Casher:EntityBase
{
	public string Name { get; set; }=string.Empty;

	public List<Payment>? Payment { get; set; }

	public DateTime PayTime { get; set; }
}
