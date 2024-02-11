using Hospital.Api.Model;
using Hospital.Model;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Infrastructure.Database
{
	public interface IHospitalContext
	{
		DbSet<HospitalModel> Hospitals { get; set; }

		DbSet<Doctor> Doctors { get; set; }

		DbSet<Patient> Patients { get; set; }

		DbSet<Worker> Workers { get; set; }

		DbSet<Branch> Branches { get; set; }

		DbSet<Salary> Salarys { get; set; }

		DbSet<Medicine> Medicines { get; set; }
	
		DbSet<Disease> Diseases { get; set; }
	
		DbSet<Casher> Cashers { get; set; }
	
		DbSet<Appointment> Appointments { get; set; }
	
		DbSet<Service> Services { get; set; }
	
		DbSet<Floor> Floors { get; set; }
	
		DbSet<Room> Rooms { get; set; }

		DbSet<Department> Departments { get; set; }
	}
}
