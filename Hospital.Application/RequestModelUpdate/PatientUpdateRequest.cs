using Hospital.Application.Entity;
using Hospital.Domen.Enam;

namespace Hospital.Application.RequestModelUpdate;

public class PatientUpdateRequest:EntityBaseUpdateRequest
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public DateTime DateRegister { get; set; }

    public string Disease { get; set; } = string.Empty;

    public Guid RoomId { get; set; }

    public PatientStatus State { get; set; }
}
