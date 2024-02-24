using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Room : EntityBase
{
	public int RoomNumber { get; set; }

	public Floor? Floor { get; set; }
	public Guid FloorId { get; set; }

	public List<Patient>? Patients { get; set; }
}
