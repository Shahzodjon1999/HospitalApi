using Hospital.Api.Abstract;

namespace Hospital.Api.Model
{
	public class DoctorPatient:EntityBase
	{
		public Doctor? Doctor { get; set; }
		public Guid DoctorID { get; set; }

		public Patient? Patient { get; set; }
		public Guid PatientId { get; set; }
	}
}
