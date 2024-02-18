using Hospital.Api.Entity;
using Hospital.Api.Model;

namespace Hospital.Api.ResponseModel
{
	public class DoctorResponse:EntityBaseResponse
	{
		public string Positions { get; set; } = string.Empty;

		public Guid DepartmentId { get; set; }

		public List<DoctorPatient>? DoctorPatients { get; set; }
	}
}
