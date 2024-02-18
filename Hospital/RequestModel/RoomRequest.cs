using Hospital.Api.Entity;

namespace Hospital.Api.RequestModel
{
    public class RoomRequest : EntityBaseRequest
    {
		public int RoomNumber { get; set; }

		public Guid FloorId { get; set; }
	}
}
