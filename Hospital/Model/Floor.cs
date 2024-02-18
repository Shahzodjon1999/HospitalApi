﻿using Hospital.Api.Abstract;

namespace Hospital.Api.Model;

public class Floor : EntityBase
{
	public string Name { get; set; } = string.Empty;

	public int FloorNumber { get; set; }

	public List<Room>? Rooms { get; set; }
}
