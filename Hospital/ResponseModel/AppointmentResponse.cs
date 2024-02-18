using Hospital.Api.Entity;

namespace Hospital.Api.ResponseModel
{
	public class AppointmentResponse:EntityBaseResponse
	{
		public Guid DoctorId { get; set; }

		public DateTime AppointmentDate { get; set; }
	}
}
