using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Models;

public class Services:EntityBase
{
	[BsonElement("name")]
	public string Name { get; set; } = string.Empty;

	[BsonElement("amount")]
	public double Amount { get; set; }
}
