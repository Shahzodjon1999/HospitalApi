using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

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
			RoomNumber= item.RoomNumber,
		};
	}

    public static IEnumerable<RoomResponse> MapToRoomResponsList(this IQueryable<Room> rooms)
    {
        List<RoomResponse> roomlist = new List<RoomResponse>();
        foreach (var item in rooms)
        {
            var result = new RoomResponse
            {
                Id = item.Id,
                FloorId = item.FloorId,
                RoomNumber = item.RoomNumber,
            };
            roomlist.Add(result);
        }
        return roomlist;
    }
}
