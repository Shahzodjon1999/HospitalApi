using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Room : EntityBase
{
	public int RoomNumber { get; set; }

    public int Status { get; set; }
    [JsonIgnore]
    public Floor? Floor { get; set; }
    [JsonIgnore]
    public Guid FloorId { get; set; }
    [JsonIgnore]
    public List<Patient>? Patients { get; set; }
}
