using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;

namespace Hospital.Infrastructure.Repositories;

public class ClientRepository:BaseRepository<Client>,  IClientRepository
{
    public ClientRepository(HospitalContext context) : base(context)
    {
    }
}
