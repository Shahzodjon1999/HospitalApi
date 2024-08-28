using FluentValidation;
using FluentValidation.AspNetCore;
using Hospital.Application.Authentication;
using Hospital.Application.AutoMapping;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Hospital.Application.Sms;
using Hospital.Application.UpdateRequestModel;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen; 

namespace Hospital.Infrastructure;

public static class ConfigurationServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //Added AutoMapping
        services.AddAutoMapper(typeof(HospitAutoMap));

        //addedSwagerConfigure
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    
        //adding custom Auth
        services.AddAuthToken();
        //Added Sql server connection string
        services.AddDbContext<HospitalContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IFloorRepository, FloorRepository>();
        services.AddScoped<IHospitalRepository,HospitalRepository>();
        services.AddScoped<IPatientRepository,PatientRepository>();
        services.AddScoped<IRoomRepository,RoomRepository>();
        services.AddScoped<IWorkerRepository, WorkerRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ISalaryRepository, SalaryRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IQueueEntryRepository, QueueEntryRepository>();

        services.AddScoped<IGenericService<DoctorRequest,DoctorUpdateRequest,DoctorResponse>, DoctorService>();
        services.AddScoped<IGenericService<HospitalRequest,HospitalUpdateRequest,HospitalResponse>, HospitalService>();
        services.AddScoped<IGenericService<PatientRequest,PatientUpdateRequest,PatientResponse>, PatientService>();
        services.AddScoped<IGenericService<WorkerRequest,WorkerUpdateRequest,WorkerResponse>, WorkerService>();
        services.AddScoped<IGenericService<AppointmentRequest,AppointmentUpdateRequest,AppointmentResponse>, AppointmentService>();
        services.AddScoped<IGenericService<BranchRequest,BranchUpdateRequest,BranchResponse>, BranchService>();
        services.AddScoped<IGenericService<DepartmentRequest,DepartmentUpdateRequest, DepartmentResponse>, DepartmentService>();
        services.AddScoped<IGenericService<FloorRequest,FloorUpdateRequest,FloorResponse>, FloorService>();
        services.AddScoped<IGenericService<RoomRequest,RoomUpdateRequest,RoomResponse>, RoomService>();
        services.AddScoped<IGenericService<RoleRequest,RoleUpdateRequest,RoleResponse>, RoleService>();
        services.AddScoped<IGenericService<SalaryRequest,SalaryUpdateRequest,SalaryResponse>, SalaryService>();
        services.AddScoped<IGenericService<PositionRequest, PositionUpdateRequest, PositionResponse>, PositionService>();
        services.AddScoped<IGenericService<ClientRequest, ClientUpdateRequest, ClientResponse>, ClientService>();
        

        services.AddScoped<PatientService>();
        services.AddScoped<AppointmentService>();
        services.AddScoped<QueueEntryService>();

        services.AddScoped<AuthService>();
        services.AddScoped<ClientService>();

        return services;
    }

    public static IServiceCollection AddAppValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssembly(typeof(AppointmentRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(AuthRequest).Assembly);


        services.AddValidatorsFromAssembly(typeof(BranchRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(DepartmentRequest).Assembly);


        services.AddValidatorsFromAssembly(typeof(DoctorRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(FloorRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(HospitalRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(PatientRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(RoleRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(RoomRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(SalaryRequest).Assembly);

        services.AddValidatorsFromAssembly(typeof(WorkerRequest).Assembly);

        return services;
    }
}
