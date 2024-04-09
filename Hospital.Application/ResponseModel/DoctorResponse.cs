using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel;

public class DoctorResponse:EntityBaseResponse
{
	public string Positions { get; set; } = string.Empty;

	public Guid DepartmentId { get; set; }
    [JsonIgnore]
    public List<DoctorPatient>? DoctorPatients { get; set; }
}
