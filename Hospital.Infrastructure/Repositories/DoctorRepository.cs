using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;

namespace Hospital.Infrastructure.Repositories;

public class DoctorRepository:BaseRepository<Doctor>,IDoctorRepository
{
    private readonly HospitalContext _context;

    public DoctorRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public override IQueryable<Doctor> GetAll()
    {
        return _context.Doctors;
    }
}
