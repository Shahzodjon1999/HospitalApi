using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.ResponseModel;

public class FloorResponse:EntityBaseResponse
{
	public string Name { get; set; } = string.Empty;

	public int FloorNumber { get; set; }
    [JsonIgnore]
    public List<Room>? Rooms { get; set; }
}
