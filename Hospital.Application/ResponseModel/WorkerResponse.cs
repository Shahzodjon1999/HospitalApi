using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record WorkerResponse:EntityBaseResponse
{
	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

	public string Address { get; set; } = string.Empty;

	public DateTime DateOfBirth { get; set; }

	public DateTime DateRegister { get; set; }

	public double Maney { get; set; }

	public string Role { get; set; } = string.Empty;
}
