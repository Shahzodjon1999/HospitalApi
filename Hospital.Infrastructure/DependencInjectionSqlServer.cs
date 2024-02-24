using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Repositories;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure;

	public static class DependencInjectionSqlServer
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HospitalContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient(typeof(IHospitalDbRepository<>), typeof(HospitalDbRepository<>));

        services.AddScoped<IGenericService<DoctorRequest, DoctorResponse>, DoctorService>();
        services.AddScoped<IGenericService<HospitalRequest, HospitalResponse>, HospitalService>();
        services.AddScoped<IGenericService<PatientRequest, PatientResponse>, PatientService>();
        services.AddScoped<IGenericService<WorkerRequest, WorkerResponse>, WorkerService>();
        services.AddScoped<IGenericService<AppointmentRequest, AppointmentResponse>, AppointmentService>();
        services.AddScoped<IGenericService<BranchRequest, BranchResponse>, BranchService>();
        services.AddScoped<IGenericService<DepartmentRequest, DepartmentResponse>, DepartmentService>();
        services.AddScoped<IGenericService<FloorRequest, FloorResponse>, FloorService>();
        services.AddScoped<IGenericService<RoomRequest, RoomResponse>, RoomService>();
        return services;
    }
}
