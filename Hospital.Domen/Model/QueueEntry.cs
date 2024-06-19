using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class QueueEntry: EntityBase
{
    public Guid AppointmentId { get; set; }
    public DateTime EnqueueTime { get; set; }
    public DateTime? DequeueTime { get; set; }

    public Appointment Appointment { get; set; }
}
