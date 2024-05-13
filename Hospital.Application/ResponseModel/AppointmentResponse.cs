using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record AppointmentResponse: EntityBaseResponse
{
    public string DoctorName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
}
