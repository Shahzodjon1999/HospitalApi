using Hospital.Abstract;
using Hospital.Model;

namespace Hospital.Models
{
	public class Room:EntityBase
	{
		public string Name { get; set; } = string.Empty;

		public int RoomNumber { get; set; }

		public Floor? Floor { get; set; } 

		public List<Patient>? Patients { get; set; }
	}
}
