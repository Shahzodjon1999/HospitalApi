using Hospital.Application.CQRS.Commands.Creates;
using Hospital.Application.Middlewares;
using Hospital.Infrastructure;
using Hospital.Infrastructure.Database;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hospital.Api;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

        //add Validations
        builder.Services.AddAppValidation();

        //add serilog
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

        //added Madiater
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateWorkerCommand).Assembly));

        //add Configration Service for all services
        builder.Services.AddApplication(builder.Configuration);

		//Add Odata Options
		builder.Services.AddControllers()
			.AddOData(option=>option.Select().Filter().Count().OrderBy().Expand());

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

        var app = builder.Build();


        //// Применение миграций
        //using (var scope = app.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<HospitalContext>();
        //    db.Database.Migrate();
        //}


        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductsAPI v1"));
		}
        //Enable CORS 
        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.UseHttpsRedirection();
        app.UseStaticFiles(); // This enables serving of static files from wwwroot
        app.UseAuthentication();
        app.UseAuthorization();

		app.UseMiddleware<GlobalExceptionMiddleware>();
		app.UseMiddleware<ApplicationKeyMiddleware>();
		app.UseMiddleware<EndpointListenerMiddleware>();

		app.MapControllers();

		app.Run();
	}
}
