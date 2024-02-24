using Hospital.Domen.Abstract;
using Hospital.Domen.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database;

public class HospitalContext : DbContext, IHospitalContext
{
    public HospitalContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<EntityBase>();

        var hospital = new Domen.Model.Hospital
        {
            Name = "Обласной болница",

            Location = "Абрешим",
            // I Have Branches List in the Hospital model But I have problem how can I add Branch what do you think about this, Plase Help me?
        };
        var hospital1 = new Domen.Model.Hospital()
        {
            Name = "Гор болница",

            Location = "Гулистон",
        };

        modelBuilder.Entity<Domen.Model.Hospital>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasData(hospital, hospital1);
            entity.HasMany<Branch>(b => b.Branches)
            .WithOne(h => h.HospitalModel)
            .HasForeignKey(k => k.HospitalID);
        });
        modelBuilder.Entity<Branch>(en =>
        {
            en.HasKey(p => p.Id);
            en.HasMany(b => b.Departments)
            .WithOne(d => d.Branch)
            .HasForeignKey(d => d.BranchID);
        });

        modelBuilder.Entity<Department>(en =>
        {
            en.HasKey(p => p.Id);
            en.HasMany(d => d.Doctors)
            .WithOne(d => d.Department)
            .HasForeignKey(k => k.DepartmentId);

        });

        modelBuilder.Entity<Room>(en =>
        {
            en.HasKey(p => p.Id);
            en.HasMany(p => p.Patients)
            .WithOne(r => r.Room)
            .HasForeignKey(k => k.RoomID);
        });
        modelBuilder.Entity<Floor>(en =>
        {
            en.HasKey(p => p.Id);
            en.HasMany(r => r.Rooms)
            .WithOne(f => f.Floor)
            .HasForeignKey(k => k.FloorId);
        });

        modelBuilder.Entity<DoctorPatient>().HasKey(p => new { p.DoctorID, p.PatientId });
        modelBuilder.Entity<DoctorPatient>(en =>
        {
            en.HasOne(p => p.Doctor)
            .WithMany(m => m.DoctorPatients)
            .HasForeignKey(k => k.DoctorID);
        });
        modelBuilder.Entity<DoctorPatient>(en =>
        {
            en.HasOne(p => p.Patient)
            .WithMany(p => p.DoctorPatients)
            .HasForeignKey(k => k.PatientId);
        });

        modelBuilder.Entity<DepartmentPatient>().HasKey(k => new { k.DepartmentId, k.PatientId });
        modelBuilder.Entity<DepartmentPatient>(en =>
        {
            en.HasOne(d => d.Department)
            .WithMany(m => m.DepartmentPatients)
            .HasForeignKey(k => k.DepartmentId);
        });
        modelBuilder.Entity<DepartmentPatient>(en =>
        {
            en.HasOne(d => d.Patient)
            .WithMany(m => m.DepartmentPatients)
            .HasForeignKey(k => k.PatientId);
        });

        modelBuilder.Entity<Worker>(en =>
        {
            en.HasKey(p => p.Id);
        });
        modelBuilder.Entity<Appointment>(en =>
        {
            en.HasKey(p => p.Id);
            en.Ignore(d => d.Doctor);
        });
    }

    public DbSet<Domen.Model.Hospital> Hospitals { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Worker> Workers { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<Floor> Floors { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<DoctorPatient> DoctorPatients { get; set; }

    public DbSet<DepartmentPatient> DepartmentPatients { get; set; }
}
