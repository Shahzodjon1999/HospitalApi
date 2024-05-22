using AutoMapper;
using Hospital.Application.CQRS.Commands.Creates;
using Hospital.Application.CQRS.Commands.Updates;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.UpdateRequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.AutoMapping;

public class HospitAutoMap: Profile
{
    public HospitAutoMap()
    {
        CreateMap<HospitalRequest, Domen.Model.Hospital>();
        CreateMap<HospitalUpdateRequest, Domen.Model.Hospital>();
        CreateMap<Domen.Model.Hospital, HospitalResponse>();

        CreateMap<Appointment, AppointmentResponse>();
        CreateMap<AppointmentUpdateRequest, Appointment>();
        CreateMap<AppointmentRequest, Appointment>();

        CreateMap<Branch, BranchResponse>();
        CreateMap<BranchUpdateRequest, Branch>();
        CreateMap<BranchRequest, Branch>();

        CreateMap<Department, DepartmentResponse>();
        CreateMap<DepartmentUpdateRequest, Department>();
        CreateMap<DepartmentRequest, Department>();

        CreateMap<Doctor, DoctorResponse>();
        CreateMap<DoctorUpdateRequest, Doctor>();
        CreateMap<DoctorRequest, Doctor>();

        CreateMap<Floor, FloorResponse>();
        CreateMap<FloorUpdateRequest, Floor>();
        CreateMap<FloorRequest, Floor>();

        CreateMap<Patient, PatientResponse>()
            .ForMember(p => p.RoomNumber, n => n.MapFrom(n => n.Room.RoomNumber));
        CreateMap<PatientUpdateRequest, Patient>();
        CreateMap<PatientRequest, Patient>();

        CreateMap<Room, RoomResponse>();
        CreateMap<RoomUpdateRequest, Room>();
        CreateMap<RoomRequest, Room>();

        CreateMap<Worker, WorkerResponse>();
        CreateMap<WorkerUpdateRequest, Worker>()
            .ForMember(dest => dest.DateRegister, opt => opt.Ignore());
        CreateMap<WorkerRequest, Worker>();

        CreateMap<Role, RoleResponse>();
        CreateMap<RoleUpdateRequest, Role>();
        CreateMap<RoleRequest,Role>();

        CreateMap<Salary, SalaryResponse>();
        CreateMap<SalaryUpdateRequest, Salary>();
        CreateMap<SalaryRequest, Salary>();

        CreateMap<AuthRequest, Auth>();

        CreateMap<Position, PositionResponse>();
        CreateMap<PositionUpdateRequest, Position>();
        CreateMap<PositionRequest, Position>();

        CreateMap<Client, ClientResponse>();
        CreateMap<ClientUpdateRequest, Client>();
        CreateMap<ClientRequest, Client>();

        CreateMap<CreateWorkerCommand, WorkerRequest>();

        CreateMap<UpdateWorkerCommand,WorkerUpdateRequest>();
    }
}
