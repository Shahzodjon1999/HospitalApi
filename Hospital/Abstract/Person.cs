﻿using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Hospital.Abstract;

public abstract class Person : EntityBase
{
	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string MidleName { get; set; } = string.Empty;

	public DateTime DataOfBirth { get; set; }

	public string PhoneNumber { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;
}
