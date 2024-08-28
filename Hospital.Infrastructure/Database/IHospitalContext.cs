using Hospital.Domen.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database;

public interface IHospitalContext
{
    DbSet<Client> Clients { get; set; }
    DbSet<QueueEntry> QueueEntrys { get; set; }
    DbSet<Salary> Salarys { get; set; }
    DbSet<Position> Positions { get; set; }
    DbSet<Auth> Auths { get; set; }
    DbSet<Domen.Model.Hospital> Hospitals { get; set; }

    DbSet<Doctor> Doctors { get; set; }

    DbSet<Patient> Patients { get; set; }

    DbSet<Worker> Workers { get; set; }

    DbSet<Branch> Branches { get; set; }

    DbSet<Appointment> Appointments { get; set; }

    DbSet<Floor> Floors { get; set; }

    DbSet<Room> Rooms { get; set; }

    DbSet<Department> Departments { get; set; }

    DbSet<Role> Roles { get; set; }
}
