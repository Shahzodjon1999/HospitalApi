using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record AppointmentRequest :EntityBaseRequest
{
    public string Name { get; set; } = string.Empty;

    public Guid DoctorId { get; set; }
	 
	public DateTime AppointmentDate { get; set; }
}
