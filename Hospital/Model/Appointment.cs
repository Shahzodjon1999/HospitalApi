using Hospital.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospital.Api.Model
{
	public class Appointment : EntityBase
	{
		[BsonElement("patient_id")]
		public int PatientId { get; set; }

		[BsonElement("doctor_id")]
		public int DoctorId { get; set; }

		[BsonElement("appointment_date")]
		public DateTime AppointmentDate { get; set; }
    }
}
