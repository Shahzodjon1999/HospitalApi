using Hospital.Domen.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database;

public interface IHospitalContext
{
    DbSet<Salary> Salarys { get; }
    DbSet<Position> Positions { get; }
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
