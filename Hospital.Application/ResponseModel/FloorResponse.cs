using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record FloorResponse:EntityBaseResponse
{
	public int FloorNumber { get; set; }
	public string Name { get; set; } = string.Empty;
}
