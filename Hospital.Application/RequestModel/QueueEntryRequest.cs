using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record QueueEntryRequest: EntityBaseRequest
{
    public Guid AppointmentId { get; set; }
}
