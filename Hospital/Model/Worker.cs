using Hospital.Abstract;
using Hospital.Enam;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Hospital.Models;

public class Worker:Person
{
	[BsonElement("role")]
	public string Role { get; set; } = string.Empty;

	[BsonElement("gender")]
	public Gender Gender { get; set; }

	[BsonElement("cabinet")]
	public string Cabinet { get; set; } = string.Empty;

	[BsonElement("start_work")]
	public DateTime StartWork { get; set; }

	[BsonElement("end_work")]
	public DateTime EndWork { get; set; }
}
