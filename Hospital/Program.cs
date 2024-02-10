using Hospital.Abstract;
using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.Model;
using Hospital.Api.Repositoryes;
using Hospital.Api.Services;
using Hospital.Interfaces;
using Hospital.Model;
using Hospital.Models;
using Hospital.Services;
using Microsoft.Extensions.Options;

namespace Hospital
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddSingleton(typeof(IMongoDbRepository<>), typeof(MongoRepository<>));
			
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IGenericService<Doctor>,DoctorService>();
			builder.Services.AddScoped<IGenericService<HospitalModel>, HospitalService>();
			builder.Services.AddScoped<IGenericService<Patient>, PatientService>();
			builder.Services.AddScoped<IGenericService<Worker>, WorkerService>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAPI v1"));
			}
			 
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
