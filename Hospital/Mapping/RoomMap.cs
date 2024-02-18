using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Mapping
{
	public static class RoomMap
	{
		public static Room MapToRoom(this RoomRequest request)
		{
			return new Room
			{
				Id = Guid.NewGuid(),
				FloorId = request.FloorId,
				RoomNumber= request.RoomNumber,
			};
		}

		public static RoomResponse MapToRoomResponse(this Room item)
		{
			return new RoomResponse
			{
				Id = item.Id,
				FloorId= item.FloorId,
				Patients= item.Patients,
				RoomNumber= item.RoomNumber,
			};
		}
	}
}
