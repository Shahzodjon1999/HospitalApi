using Hospital.Api.Entity;

namespace Hospital.Api.RequestModel
{
    public class AppointmentRequest:EntityBaseRequest
	{
		public Guid DoctorId { get; set; }

		public DateTime AppointmentDate { get; set; }
	}
}
