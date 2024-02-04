using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hospital.Model
{
	public class Disease:EntityBase
	{
		[BsonElement("name")]
		public string Name { get; set; } = string.Empty;

		[BsonElement("doctor_id")]
		public Guid DoctorId { get; set; }
	}
}
