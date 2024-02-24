using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class RoomRequest : EntityBaseRequest
    {
	public int RoomNumber { get; set; }

	public Guid FloorId { get; set; }
}
