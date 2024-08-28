using Hospital.Domen.Model;

namespace Hospital.Application.InterfaceRepositoryes;

public interface IAppointmentRepository:IBaseRepository<Appointment>
{
    Task<bool> CheckAppointmentExistsAsync(Guid doctorId, DateTime appointmentDate);
}
