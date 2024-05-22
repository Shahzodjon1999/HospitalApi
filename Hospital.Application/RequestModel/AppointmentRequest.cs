using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record AppointmentRequest :EntityBaseRequest
{
    public string Name { get; set; } = string.Empty;

    public string lastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public Guid DoctorId { get; set; }
	 
	public DateTime AppointmentDate { get; set; }
}
