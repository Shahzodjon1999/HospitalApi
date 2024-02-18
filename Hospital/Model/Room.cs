using Hospital.Api.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Api.Model
{
	public class Room : EntityBase
	{
		public int RoomNumber { get; set; }

		public Floor? Floor { get; set; }
		public Guid FloorId { get; set; }

		public List<Patient>? Patients { get; set; }
	}
}
