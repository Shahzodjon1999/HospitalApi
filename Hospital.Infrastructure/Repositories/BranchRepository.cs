using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class BranchRepository:BaseRepository<Branch>,IBranchRepository
{
    private readonly HospitalContext context;

    public BranchRepository(HospitalContext context) : base(context)
    {
        this.context = context;
    }

    public override IQueryable<Branch> GetAll()
    {
        var t = context.Branches.Include(s => s.Departments).Include(d=>d.HospitalModel);

        return t;
    }
}
