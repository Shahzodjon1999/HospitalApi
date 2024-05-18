using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record RoomResponse:EntityBaseResponse
{
	public int RoomNumber { get; set; }

    public int Status { get; set; }
}
