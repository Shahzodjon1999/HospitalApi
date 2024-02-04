using Hospital.Abstract;
using Hospital.Models;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Hospital.Model;

public class Floor:EntityBase
{
	[BsonElement("name")]
	public string Name { get; set; }=string.Empty;

	[BsonElement("name_floor")]
	public int NumberFloor { get; set; }

	//public List<Room>? Rooms { get; set; }
}
