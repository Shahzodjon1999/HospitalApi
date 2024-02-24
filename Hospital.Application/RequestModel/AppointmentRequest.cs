using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class AppointmentRequest:EntityBaseRequest
{
	public Guid DoctorId { get; set; }

	public DateTime AppointmentDate { get; set; }
}
