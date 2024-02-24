using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.ResponseModel
{
	public class RoomResponse:EntityBaseResponse
	{
		public int RoomNumber { get; set; }

		public Guid FloorId { get; set; }

		public List<Patient>? Patients { get; set; }
	}
}
