using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record HospitalResponse:EntityBaseResponse
{
	public string Name { get; set; } = string.Empty;

	public string Location { get; set; } = string.Empty;
}
