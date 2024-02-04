using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Model;

public class Salary:EntityBase
{
	[BsonElement("amount")]
	public double Amount { get; set; }

	[BsonElement("worker_id")]
	public ulong WorkerId { get; set; }

	[BsonElement("bonus")]
	public double Bonus { get; set; }
}
