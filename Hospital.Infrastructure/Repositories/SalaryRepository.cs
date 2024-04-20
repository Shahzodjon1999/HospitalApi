using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;

namespace Hospital.Infrastructure.Repositories;

public class SalaryRepository : BaseRepository<Salary>, ISalaryRepository
{
    public SalaryRepository(HospitalContext context) : base(context)
    {
    }
}
