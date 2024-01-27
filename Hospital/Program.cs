using Hospital.Api.Repositoryes;
using Hospital.Api.Services;
using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Model;
using Hospital.Models;
using Hospital.Repositoryes;
using Hospital.Services;

namespace Hospital
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IGenericService<Doctor>,DoctorService>();
			builder.Services.AddScoped<IGenericService<HospitalModel>, HospitalService>();
			builder.Services.AddScoped<IGenericService<Patient>, PatientService>();
			builder.Services.AddScoped<IGenericService<Worker>, WorkerService>();

			builder.Services.AddSingleton(typeof(IMemoryRepository<>),typeof(MemoryRepository<>));

			
			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			 
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
