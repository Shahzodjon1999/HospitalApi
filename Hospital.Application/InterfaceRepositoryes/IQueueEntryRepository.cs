using Hospital.Domen.Model;

namespace Hospital.Application.InterfaceRepositoryes;

public interface IQueueEntryRepository
{
    Task EnqueueAppointmentAsync(QueueEntry queueEntry);
    Task<QueueEntry> DequeueAppointmentAsync();
    Task<List<QueueEntry>> GetQueueAsync();
}
