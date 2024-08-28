using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Appointment : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public string lastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public  Doctor? Doctor { get; set; }
	
	public Guid DoctorId { get; set; }

	public DateTime AppointmentDate { get; set; }
}
