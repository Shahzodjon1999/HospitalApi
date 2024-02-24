using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.ResponseModel
{
	public class FloorResponse:EntityBaseResponse
    {
		public string Name { get; set; } = string.Empty;

		public int FloorNumber { get; set; }

		public List<Room>? Rooms { get; set; }
	}
}
