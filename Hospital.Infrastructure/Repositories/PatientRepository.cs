using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class PatientRepository:BaseRepository<Patient>,IPatientRepository
{
    private readonly HospitalContext _context;

    private readonly IMapper _mapper;
    public PatientRepository(HospitalContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public override IQueryable<Patient> GetAll()
    {
        return _context.Patients;
    }

    public IQueryable<PatientInfoResponse> GetAllInfoPatient()
    {
        // return _context.Patients.Include(r => r.Room).ThenInclude(f => f.Floor).ThenInclude(d => d.Department).ThenInclude(b => b.Branch).ThenInclude(h => h.HospitalModel);
        var patients = _context.Patients
               .Include(r => r.Room)
               .ThenInclude(f => f.Floor)
               .ThenInclude(d => d.Department)
               .ThenInclude(b => b.Branch)
        .ThenInclude(h => h.HospitalModel);

        var patientInfoResponses = patients.Select(patient => _mapper.Map<PatientInfoResponse>(patient));

        return patientInfoResponses;
    }
}
