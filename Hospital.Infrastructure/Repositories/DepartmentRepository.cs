using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class DepartmentRepository:BaseRepository<Department>,IDepartmentRepository
{
    private readonly HospitalContext _context;

    public DepartmentRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public override IQueryable<Department> GetAll()
    {
        return _context.Departments.Include(b => b.Branch);
    }
}
