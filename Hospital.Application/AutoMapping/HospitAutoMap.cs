using AutoMapper;
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

        CreateMap<Appointment, AppointmentResponse>()
            .ForMember(d=>d.DoctorName, d1=>d1.MapFrom(d=>d.Doctor.FirstName));
        CreateMap<AppointmentUpdateRequest, Appointment>();
        CreateMap<AppointmentRequest, Appointment>();

        CreateMap<Branch, BranchResponse>()
            .ForMember(h=>h.HospitalName,h=>h.MapFrom(h=>h.HospitalModel.Name));
        CreateMap<BranchUpdateRequest, Branch>();
        CreateMap<BranchRequest, Branch>();

        CreateMap<Department, DepartmentResponse>()
            .ForMember(b => b.BranchName, b => b.MapFrom(b => b.Branch.Name));
        CreateMap<DepartmentUpdateRequest, Department>();
        CreateMap<DepartmentRequest, Department>();

        CreateMap<Doctor, DoctorResponse>()
            .ForMember(d => d.DepartmentName, n => n.MapFrom(d => d.Department.Name));
        CreateMap<DoctorUpdateRequest, Doctor>();
        CreateMap<DoctorRequest, Doctor>();

        CreateMap<Floor, FloorResponse>();
        CreateMap<FloorUpdateRequest, Floor>();
        CreateMap<FloorRequest, Floor>();

        CreateMap<Patient, PatientResponse>()
            .ForMember(p => p.RoomNumber, n => n.MapFrom(n => n.Room.RoomNumber));
        CreateMap<PatientUpdateRequest, Patient>();
        CreateMap<PatientRequest, Patient>();

        CreateMap<Room, RoomResponse>()
            .ForMember(n=>n.FloorNumber, f=>f.MapFrom(n=>n.Floor.FloorNumber));
        CreateMap<RoomUpdateRequest, Room>();
        CreateMap<RoomRequest, Room>();

        CreateMap<Worker, WorkerResponse>()
            .ForMember(n => n.Maney, m => m.MapFrom(m => m.Salary.Amount))
            .ForMember(n => n.Role, m => m.MapFrom(m => m.Role.Name));  
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
    }
}
