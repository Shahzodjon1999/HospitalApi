using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Model
{
	public class Medicine:EntityBase
	{
		[BsonElement("name")]
		public string Name { get; set; } = string.Empty;

		[BsonElement("location")]
		public string Location { get; set; } = string.Empty;
	}
}
