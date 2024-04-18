using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Repositories;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Hospital.Application.UpdateRequestModel;
using Hospital.Domen.Model;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure;

	public static class DependencInjectionSqlServer
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HospitalContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IFloorRepository, FloorRepository>();
        services.AddScoped<IHospitalRepository,HospitalRepository>();
        services.AddScoped<IPatientRepository,PatientRepository>();
        services.AddScoped<IRoomRepository,RoomRepository>();
        services.AddScoped<IWorkerRepository, WorkerRepository>();
        services.AddScoped<IUserRepository, UserRepository>();


        services.AddScoped<IGenericService<DoctorRequest,DoctorUpdateRequest,DoctorResponse>, DoctorService>();
        services.AddScoped<IGenericService<HospitalRequest,HospitalUpdateRequest,HospitalResponse>, HospitalService>();
        services.AddScoped<IGenericService<PatientRequest,PatientUpdateRequest,PatientResponse>, PatientService>();
        services.AddScoped<IGenericService<WorkerRequest,WorkerUpdateRequest,WorkerResponse>, WorkerService>();
        services.AddScoped<IGenericService<AppointmentRequest,AppointmentUpdateRequest,AppointmentResponse>, AppointmentService>();
        services.AddScoped<IGenericService<BranchRequest,BranchUpdateRequest,BranchResponse>, BranchService>();
        services.AddScoped<IGenericService<DepartmentRequest,DepartmentUpdateRequest, DepartmentResponse>, DepartmentService>();
        services.AddScoped<IGenericService<FloorRequest,FloorUpdateRequest,FloorResponse>, FloorService>();
        services.AddScoped<IGenericService<RoomRequest,RoomUpdateRequest,RoomResponse>, RoomService>();
        services.AddScoped<AuthService>();
        return services;
    }
}
