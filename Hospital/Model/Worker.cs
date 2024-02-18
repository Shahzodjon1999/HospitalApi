using Hospital.Abstract;
using Hospital.Model;
using System.Text.Json.Serialization;
namespace Hospital.Models;

public class Worker:Person
{
	public string Role { get; set; } = string.Empty;
}
