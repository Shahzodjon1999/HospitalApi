using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.ResponseModel;

public record FloorResponse:EntityBaseResponse
{
	public int FloorNumber { get; set; }
	public string Name { get; set; } = string.Empty;
	public List<Room>? Rooms { get; set; }
}
