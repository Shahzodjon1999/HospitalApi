using Hospital.Abstract;
using Hospital.Enam;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Hospital.Models;

public class Patient:Person
{
	[BsonElement("disease_name")]
	public string DiseaseName { get; set; } = string.Empty;

	//public List<Doctor>? Doctors { get; set; }
	[BsonElement("gender")]
	public Gender Gender { get; set; }

	[BsonElement("floor_number")]
	public int FloorNumber { get; set; }

	[BsonElement("room_number")]
	public int RoomNumber { get; set; }

	//public PatientStatus State { get; set; }
}
