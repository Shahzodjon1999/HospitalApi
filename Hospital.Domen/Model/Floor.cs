using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Floor : EntityBase
{
	public string Name { get; set; } = string.Empty;

	public int FloorNumber { get; set; }

	public List<Room>? Rooms { get; set; }
}
