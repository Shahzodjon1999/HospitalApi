using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;

namespace Hospital.Infrastructure.Repositories;

public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
{
    private readonly HospitalContext _context;

    public WorkerRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }
    public override IQueryable<Worker> GetAll()
    {
        return _context.Workers;
    }
}
