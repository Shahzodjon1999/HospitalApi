using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel
{
	public class RoomResponse:EntityBaseResponse
	{
		public int RoomNumber { get; set; }

		public Guid FloorId { get; set; }
		[JsonIgnore]
		public List<Patient>? Patients { get; set; }
	}
}
