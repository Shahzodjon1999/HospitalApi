using Hospital.Abstract;
using Hospital.Models;
using System.Collections.Generic;

namespace Hospital.Model;

public class Floor:EntityBase
{
	public string Name { get; set; }=string.Empty;

	public int NumberFloor { get; set; }

	public List<Room>? Rooms { get; set; }
}
