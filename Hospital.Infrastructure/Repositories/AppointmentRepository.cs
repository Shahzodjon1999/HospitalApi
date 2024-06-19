using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Repositories;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class AppointmentRepository:BaseRepository<Appointment>,IAppointmentRepository
{
    private readonly HospitalContext _context;

    public AppointmentRepository(HospitalContext context):base(context)
    {
        _context = context;
    }

    public async Task<bool> CheckAppointmentExistsAsync(Guid doctorId, DateTime appointmentDate)
    {
        return await _context.Appointments.AnyAsync(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate);
    }
    public override IQueryable<Appointment> GetAll()
    {
        return _context.Appointments;  
    }
}
