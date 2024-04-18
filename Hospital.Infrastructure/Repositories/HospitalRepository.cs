using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Application.ResponseModel;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class HospitalRepository:BaseRepository<Domen.Model.Hospital>,IHospitalRepository
{
    private readonly HospitalContext _context;

    public HospitalRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public override IQueryable<Domen.Model.Hospital> GetAll()
    {
        return _context.Hospitals.Include(b => b.Branches);
    }
}
