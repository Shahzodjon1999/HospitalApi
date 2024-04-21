using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class AuthRepository:BaseRepository<Auth>,IAuthRepository
{
    private readonly HospitalContext _context;

    public AuthRepository(HospitalContext context):base(context)
    {
        _context = context;
    }
    public override IQueryable<Auth> GetAll()
    {
        return _context.Auths.Include(d => d.Worker).ThenInclude(r=>r.Role);
    }
}
