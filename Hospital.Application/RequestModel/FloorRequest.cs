using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record FloorRequest : EntityBaseRequest
{
	public string Name { get; set; } = string.Empty;

	public int FloorNumber { get; set; }

    public Guid DepartmentId { get; set; }
}
