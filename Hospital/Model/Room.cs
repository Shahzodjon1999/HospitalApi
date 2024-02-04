using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Models
{
	public class Room:EntityBase
	{
		[BsonElement("name")]
		public string Name { get; set; } = string.Empty;

		[BsonElement("number_room")]
		public int NumberRoom { get; set; }
	}
}
