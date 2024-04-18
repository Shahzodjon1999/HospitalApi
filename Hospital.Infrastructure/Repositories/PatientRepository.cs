using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class PatientRepository:BaseRepository<Patient>,IPatientRepository
{
    private readonly HospitalContext _context;

    public PatientRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public override IQueryable<Patient> GetAll()
    {
        return _context.Patients.Include(d => d.DoctorPatients).Include(d => d.DepartmentPatients);
    }
}
