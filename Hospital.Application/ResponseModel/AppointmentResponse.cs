using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel;

public class AppointmentResponse: EntityBaseResponse
{
    [JsonIgnore]
    public Doctor? Doctor { get; set; }

    public Guid DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }
}
