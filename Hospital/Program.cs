using Hospital.Infrastructure;
using Serilog;

namespace Hospital.Api;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		//Add Sql Server and Dependency injection
		builder.Services.AddApplication(builder.Configuration);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		//add serilog
	     Log.Logger = new LoggerConfiguration()
			.ReadFrom.Configuration(builder.Configuration).CreateLogger();

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
