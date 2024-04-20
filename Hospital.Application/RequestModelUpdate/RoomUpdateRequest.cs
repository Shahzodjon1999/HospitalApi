using Hospital.Application.Entity;

namespace Hospital.Application.RequestModelUpdate;

public record RoomUpdateRequest:EntityBaseUpdateRequest
{
    public Guid FloorId { get; set; }
    public int RoomNumber { get; set; }
}
