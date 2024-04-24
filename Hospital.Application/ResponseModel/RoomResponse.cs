using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record RoomResponse:EntityBaseResponse
{
	public int FloorNumber { get; set; }
	public int RoomNumber { get; set; }
}
