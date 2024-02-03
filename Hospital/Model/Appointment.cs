using Hospital.Abstract;

namespace Hospital.Api.Model
{
	public class Appointment : EntityBase
	{
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
