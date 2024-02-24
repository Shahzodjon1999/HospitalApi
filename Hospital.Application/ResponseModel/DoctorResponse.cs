using Hospital.Application.Entity;
using Hospital.Domen.Model;

namespace Hospital.Application.ResponseModel
{
	public class DoctorResponse:EntityBaseResponse
	{
		public string Positions { get; set; } = string.Empty;

		public Guid DepartmentId { get; set; }

		public List<DoctorPatient>? DoctorPatients { get; set; }
	}
}
