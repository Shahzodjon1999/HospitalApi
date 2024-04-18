using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class RoomRepository:BaseRepository<Room>,IRoomRepository
{
    private readonly HospitalContext context;

    public RoomRepository(HospitalContext context) : base(context)
    {
        this.context = context;
    }
    public override IQueryable<Room> GetAll()
    {
        return _context.Rooms.Include(p => p.Patients);
    }
}
