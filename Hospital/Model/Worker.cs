using Hospital.Abstract;
using Hospital.Enam;
using System;
namespace Hospital.Models;

public class Worker:Person
{
	public string Role { get; set; } = string.Empty;

	public Gender Gender { get; set; }

	public string Cabinet { get; set; } = string.Empty;

	public DateTime StartWork { get; set; }

	public DateTime EndWork { get; set; }
}
