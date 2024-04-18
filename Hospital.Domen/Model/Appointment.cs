using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Appointment : EntityBase
{
    public  Doctor? Doctor { get; set; }
	
	public Guid DoctorId { get; set; }

    public string Name { get; set; }=string.Empty;

	public DateTime AppointmentDate { get; set; }
}
