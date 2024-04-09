using Hospital.Application.Authentication;
using Hospital.Application.Middlewares;
using Hospital.Infrastructure;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hospital.Api;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

        //add serilog
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

        //adding custom Auth
        builder.Services.AddAuthToken();

		//Add Sql Server and Dependency injection
		builder.Services.AddApplication(builder.Configuration);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		//addedSwagerConfigure
        builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        var app = builder.Build();

		if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAPI v1"));
		}
        //Enable CORS 
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

		app.UseMiddleware<GlobalExceptionMiddleware>();
		app.UseMiddleware<ApplicationKeyMiddleware>();
		app.UseMiddleware<EndpointListenerMiddleware>();

		app.MapControllers();

		app.Run();
	}
}
