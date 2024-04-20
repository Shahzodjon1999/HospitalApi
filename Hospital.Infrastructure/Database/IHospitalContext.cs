using Hospital.Domen.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hospital.Infrastructure.Database;

public interface IHospitalContext
{
    DbSet<Salary> Salarys { get; }
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

    DbSet<DoctorPatient> DoctorPatients { get; set; }

    DbSet<DepartmentPatient> DepartmentPatients { get; set; }

    DbSet<Role> Roles { get; set; }
}
