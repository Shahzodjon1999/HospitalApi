using Hospital.Abstract;
using Hospital.Models;

namespace Hospital.Model;

public class Floor:EntityBase
{
	public string Name { get; set; }=string.Empty;

	public int FloorNumber { get; set; }

	public List<Room>? Rooms { get; set; }
}
