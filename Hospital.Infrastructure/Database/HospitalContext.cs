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
        };
        var hospital1 = new Domen.Model.Hospital()
        {
            Name = "Гор болница",

            Location = "Гулистон",
        };
        var position = new Position()
        {
            Name = "Admin",
        };
        var worker = new Worker()
        {
            FirstName="Shahzodjon",
            LastName="Jonizoqov",
            Address="Panjakent",
            PhoneNumber="+992927758499",
            PositionId=position.Id,
            DateOfBirth=new DateTime(),
            DateRegister=new DateTime(),
        };
        var auth = new Auth()
        {
            Login="SupperAdmin123",
            Password="!@#123#@!",
            WorkerId=worker.Id,
        };
        var role = new Role()
        {
            Name="Admin",
            WorkerId=worker.Id
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
            en.HasMany(f=>f.Floors)
            .WithOne(d=>d.Department)
            .HasForeignKey(k=>k.DepartmentId);
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
        modelBuilder.Entity<Appointment>(en =>
        {
            en.HasKey(p => p.Id);
            en.HasOne(s => s.Doctor)
            .WithMany(s=>s.Appointments)
            .HasForeignKey(s=>s.DoctorId);
        });
        modelBuilder.Entity<Position>(en =>
        {
            en.HasKey(i => i.Id);
            en.HasData(position);
        });
        modelBuilder.Entity<Worker>(en =>
        {
            en.HasOne(w => w.Auth)
            .WithOne(a => a.Worker)
            .HasForeignKey<Auth>(a => a.WorkerId);
            en.HasOne(w => w.Role)
            .WithOne(r => r.Worker)
            .HasForeignKey<Role>(r => r.WorkerId);
            en.HasOne(w => w.Salary)
            .WithOne(s => s.Worker)
            .HasForeignKey<Salary>(s => s.WorkerId);
            en.HasOne(p => p.Position)
            .WithMany(p=>p.Workers)
            .HasForeignKey(i=>i.PositionId);

            en.HasData(worker);
        });
        modelBuilder.Entity<Auth>(en =>
        {
            en.HasKey(k => k.Id);
            en.HasData(auth);
        });
        modelBuilder.Entity<Role>(en =>
        {
            en.HasKey(k => k.Id);
            en.HasData(role);
        });
    }

    public DbSet<Auth> Auths { get; set; }
    public DbSet<Position> Positions { get; set; }

    public DbSet<Domen.Model.Hospital> Hospitals { get; set; }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Worker> Workers { get; set; }

    public DbSet<Branch> Branches { get; set; }

    public DbSet<Appointment> Appointments { get; set; }

    public DbSet<Floor> Floors { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Salary> Salarys { get; set; }

    public DbSet<Role> Roles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<QueueEntry> QueueEntrys { get; set; }
}