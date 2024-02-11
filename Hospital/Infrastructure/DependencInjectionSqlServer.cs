using Hospital.Api.Infrastructure.Database;
using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.Repositoryes;
using Hospital.Api.Services;
using Hospital.Interfaces;
using Hospital.Model;
using Hospital.Models;
using Hospital.Services;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Infrastructure
{
	public static class DependencInjectionSqlServer
	{
		public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<HospitalContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddTransient(typeof(IHospitalDbRepository<>), typeof(HospitalDbRepository<>));

			services.AddTransient<IGenericService<Doctor>, DoctorService>();
			services.AddTransient<IGenericService<HospitalModel>, HospitalService>();
			services.AddTransient<IGenericService<Patient>, PatientService>();
			services.AddTransient<IGenericService<Worker>, WorkerService>();

			return services;
		}
	}
}
