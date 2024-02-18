using Hospital.Api.Abstract;

namespace Hospital.Api.Model
{
	public class Appointment : EntityBase
	{
		public Doctor? Doctor { get; set; }

		public Guid DoctorId { get; set; }

		public DateTime AppointmentDate { get; set; }
    }
}
