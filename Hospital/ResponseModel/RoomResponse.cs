using Hospital.Api.Entity;
using Hospital.Api.Model;

namespace Hospital.Api.ResponseModel
{
	public class RoomResponse:EntityBaseResponse
	{
		public int RoomNumber { get; set; }

		public Guid FloorId { get; set; }

		public List<Patient>? Patients { get; set; }
	}
}
