using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class PositionRepository:BaseRepository<Position>,IPositionRepository
{ 
    private readonly HospitalContext _context;

    public PositionRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }
    public override IQueryable<Position> GetAll()
    {
        return _context.Positions.Include(p=>p.Workers);
    }
}
