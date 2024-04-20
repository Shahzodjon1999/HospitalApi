using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Floor : EntityBase
{
	public string Name { get; set; } = string.Empty;

	public int FloorNumber { get; set; }

    [JsonIgnore]
    public List<Room>? Rooms { get; set; }
}
