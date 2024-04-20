using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record RoomRequest : EntityBaseRequest
{
	public int RoomNumber { get; set; }

	public Guid FloorId { get; set; }
}
