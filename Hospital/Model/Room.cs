using Hospital.Abstract;

namespace Hospital.Models
{
	public class Room:EntityBase
	{
		public string Name { get; set; } = string.Empty;

		public int NumberRoom { get; set; }
	}
}
