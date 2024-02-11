using Hospital.Abstract;
using Hospital.Api.Model;
using Hospital.Model;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Infrastructure.Database
{
	public class HospitalContext : DbContext , IHospitalContext
	{
        public HospitalContext(DbContextOptions options):base(options)
        {
				Database.EnsureCreated();
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<EntityBase>();

			var hospital = new HospitalModel
			{
				Name = "Обласной болница",

				Location = "Абрешим",
				// I Have Branches List in the Hospital model But I have problem how can I add Branch what do you think about this, Plase Help me?
			};
			var hospital1 = new HospitalModel()
			{
				Name = "Гор болница",

				Location = "Гулистон",
			};

			modelBuilder.Entity<HospitalModel>(entity =>
			{
				entity.HasKey(p => p.Id);
				entity.HasData(hospital, hospital1);
			});

			modelBuilder.Entity<Branch>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Department>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Doctor>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Patient>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Room>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Floor>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Worker>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Service>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Appointment>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Casher>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Disease>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Medicine>(en =>
			{
				en.HasKey(p => p.Id);
			});
			modelBuilder.Entity<Salary>(en =>
			{
				en.HasKey(p => p.Id);
			});
		}

        public DbSet<HospitalModel> Hospitals { get; set; }

		public DbSet<Doctor> Doctors { get; set; }

		public DbSet<Patient> Patients { get; set; }

		public DbSet<Worker> Workers { get; set; }

		public DbSet<Branch> Branches { get; set; }

		public DbSet<Salary> Salarys { get; set; }

	    public DbSet<Medicine> Medicines { get; set; }

		public DbSet<Disease> Diseases { get; set; }

		public DbSet<Casher> Cashers { get; set; }

		public DbSet<Appointment> Appointments { get; set; }

		public DbSet<Service> Services { get; set; }

		public DbSet<Floor> Floors { get; set; }

		public DbSet<Room> Rooms { get; set; }

		public DbSet<Department> Departments { get; set; }
	}
}
