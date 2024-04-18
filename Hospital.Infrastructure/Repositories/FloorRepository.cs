using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class FloorRepository:BaseRepository<Floor>,IFloorRepository
{
    private readonly HospitalContext _context;

    public FloorRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public override IQueryable<Floor> GetAll()
    {
        return _context.Floors.Include(r => r.Rooms);
    }
}
