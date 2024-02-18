using Hospital.Api.Entity;
using Hospital.Api.Model;

namespace Hospital.Api.ResponseModel
{
    public class FloorResponse:EntityBaseResponse
    {
		public string Name { get; set; } = string.Empty;

		public int FloorNumber { get; set; }

		public List<Room>? Rooms { get; set; }
	}
}
