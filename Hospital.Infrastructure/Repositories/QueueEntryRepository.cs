using Hospital.Application.InterfaceRepositoryes;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class QueueEntryRepository : IQueueEntryRepository
{
    protected readonly HospitalContext _context;

    public QueueEntryRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task EnqueueAppointmentAsync(QueueEntry queueEntry)
    {
        _context.QueueEntrys.Add(queueEntry);
        await _context.SaveChangesAsync();
    }

    public async Task<QueueEntry> DequeueAppointmentAsync()
    {
        var queueEntry = await _context.QueueEntrys
            .Where(q => q.DequeueTime == null)
            .OrderBy(q => q.EnqueueTime)
            .Include(q => q.Appointment)
            .ThenInclude(a => a.Doctor)
            .FirstOrDefaultAsync();

        if (queueEntry != null)
        {
            queueEntry.DequeueTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        return queueEntry;
    }

    public async Task<List<QueueEntry>> GetQueueAsync()
    {
        return await _context.QueueEntrys
            .Where(q => q.DequeueTime == null)
            .OrderBy(q => q.EnqueueTime)
            .Include(q => q.Appointment)
            .ThenInclude(a => a.Doctor)
            .ToListAsync();
    }
}
