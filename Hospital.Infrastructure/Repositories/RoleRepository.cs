using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;

namespace Hospital.Infrastructure.Repositories;

public class RoleRepository : BaseRepository<Role>,IRoleRepository
{
    public RoleRepository(HospitalContext context) : base(context)
    {
    }
}
