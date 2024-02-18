using Hospital.Api.Infrastructure.Database;
using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.InterfaceServices;
using Hospital.Api.Repositories;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;
using Hospital.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Infrastructure
{
	public static class DependencInjectionSqlServer
	{
		public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<HospitalContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddTransient(typeof(IHospitalDbRepository<>), typeof(HospitalDbRepository<>));

			services.AddScoped<IGenericService<DoctorRequest,DoctorResponse>, DoctorService>();
			services.AddScoped<IGenericService<HospitalRequest,HospitalResponse>, HospitalService>();
			services.AddScoped<IGenericService<PatientRequest,PatientResponse>, PatientService>();
			services.AddScoped<IGenericService<WorkerRequest,WorkerResponse>, WorkerService>();
			services.AddScoped<IGenericService<AppointmentRequest, AppointmentResponse>, AppointmentService>();
			services.AddScoped<IGenericService<BranchRequest, BranchResponse>, BranchService>(); 
			services.AddScoped<IGenericService<DepartmentRequest, DepartmentResponse>, DepartmentService>(); 
            services.AddScoped<IGenericService<FloorRequest, FloorResponse>, FloorService>();
			services.AddScoped<IGenericService<RoomRequest, RoomResponse>, RoomService>();
			return services;
		}
	}
}
