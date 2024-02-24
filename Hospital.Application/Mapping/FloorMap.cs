using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class FloorMap
{
	public static Floor MapToFloor(this FloorRequest request)
	{
		return new Floor
		{
			Id = Guid.NewGuid(),
			FloorNumber = request.FloorNumber,
			Name = request.Name,
		};
	}

	public static FloorResponse MapToFloorResponse(this Floor item)
	{
		return new FloorResponse
		{
			Id = item.Id,
			FloorNumber = item.FloorNumber,
			Name=item.Name,
			Rooms=item.Rooms,
		};
	}
}
