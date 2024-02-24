using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class FloorRequest : EntityBaseRequest
{
	public string Name { get; set; } = string.Empty;

	public int FloorNumber { get; set; }
}
