using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.RequestModel;

public record WorkerRequest : EntityBaseRequest
{
	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

	public DateTime DateOfBirth { get; set; }

	public DateTime DateRegister { get; set; }
}
