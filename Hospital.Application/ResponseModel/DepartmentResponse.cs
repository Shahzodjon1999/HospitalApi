using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record DepartmentResponse:EntityBaseResponse
{
	public string Name { get; set; } = string.Empty;
}
