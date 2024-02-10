using Hospital.Abstract;
using Hospital.Api.Model;
using Hospital.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hospital.Model;

public class Casher:EntityBase
{
	public string Name { get; set; }=string.Empty;

	public List<Payment>? Payment { get; set; }

	public DateTime PayTime { get; set; }
}
