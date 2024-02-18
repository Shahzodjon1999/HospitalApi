using Hospital.Abstract;
using Hospital.Api.Model;
using System.Text.Json.Serialization;

namespace Hospital.Model;

public class Casher:EntityBase
{
	public string Name { get; set; }=string.Empty;

	public DateTime PayTime { get; set; }
}
