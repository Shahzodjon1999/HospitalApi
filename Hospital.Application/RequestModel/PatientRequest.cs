using Hospital.Application.Entity;
using Hospital.Domen.Enam;

namespace Hospital.Application.RequestModel;

public class PatientRequest : EntityBaseRequest
{
	public string FirstName { get; set; } = string.Empty;

	public string LastName { get; set; } = string.Empty;

	public string PhoneNumber { get; set; } = string.Empty;

    public List<Guid>? DoctorIds { get; set; }

    public string Address { get; set; } = string.Empty;

	public DateTime DateOfBirth { get; set; }

	public DateTime DateRegister { get; set; }

	public string Disease { get; set; } = string.Empty;

	public PatientStatus State { get; set; }

	public Guid RoomId { get; set; }
}
