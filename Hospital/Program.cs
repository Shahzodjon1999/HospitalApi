using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
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

			builder.Services.AddTransient<IGenericService<Doctor>, DoctorService>();
			builder.Services.AddSingleton<IGenericRepository<Doctor>, DoctorRepository>();

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
