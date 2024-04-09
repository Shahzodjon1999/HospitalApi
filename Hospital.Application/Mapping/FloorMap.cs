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
		};
	}

    public static IEnumerable<FloorResponse> MapToFloorResponsList(this IQueryable<Floor> appointments)
    {
        List<FloorResponse> appointmentlist = new List<FloorResponse>();
        foreach (var item in appointments)
        {
            var result = new FloorResponse
            {
                Id = item.Id,
                FloorNumber = item.FloorNumber,
                Name = item.Name,
            };
            appointmentlist.Add(result);
        }
        return appointmentlist;
    }
}
