using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Appointment : EntityBase
{
    [JsonIgnore]
    public Doctor? Doctor { get; set; }
	
	public Guid DoctorId { get; set; }

	public DateTime AppointmentDate { get; set; }
    }
