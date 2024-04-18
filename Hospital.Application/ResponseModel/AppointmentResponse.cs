using Hospital.Application.Entity;

namespace Hospital.Application.ResponseModel;

public record AppointmentResponse: EntityBaseResponse
{
    public string DoctorName { get; set; }
    public string Name { get; set; }
    public DateTime AppointmentDate { get; set; }
}
