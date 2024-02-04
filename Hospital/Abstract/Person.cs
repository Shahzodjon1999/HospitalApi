using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hospital.Abstract;

public abstract class Person : EntityBase
{
	[BsonElement("first_name")]
	public string FirstName { get; set; } = string.Empty;

	[BsonElement("last_name")]
	public string LastName { get; set; } = string.Empty;

	[BsonElement("middle_name")]
	public string MidleName { get; set; } = string.Empty;

	[BsonElement("date_of_birth")]
	public DateTime DataOfBirth { get; set; }

	[BsonElement("phone_number")]
	public string PhoneNumber { get; set; } = string.Empty;

	[BsonElement("address")]
	public string Address { get; set; } = string.Empty;
}
