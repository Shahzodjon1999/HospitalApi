using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel
{
	public class AppointmentResponse:EntityBaseResponse
	{
		public Guid DoctorId { get; set; }

		public DateTime AppointmentDate { get; set; }
	}
}
