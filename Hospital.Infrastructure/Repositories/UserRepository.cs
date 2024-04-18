using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;

namespace Hospital.Infrastructure.Repositories;

public class UserRepository:BaseRepository<User>,IUserRepository
{
    public UserRepository(HospitalContext context):base(context)
    {
    }
}
