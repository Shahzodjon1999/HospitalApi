using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record AppointmentResponse: EntityBaseResponse
{
    public string Name { get; set; } = string.Empty;

    public string lastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public Guid DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }
}
