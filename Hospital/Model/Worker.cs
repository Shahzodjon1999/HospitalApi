using Hospital.Api.Abstract;
namespace Hospital.Api.Model;

public class Worker : Person
{
	public string Role { get; set; } = string.Empty;
}
