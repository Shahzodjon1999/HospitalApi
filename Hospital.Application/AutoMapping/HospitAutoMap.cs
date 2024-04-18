using AutoMapper;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
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

        CreateMap<Branch, BranchResponse>()
            .ForMember(h=>h.HospitalName,h=>h.MapFrom(h=>h.HospitalModel.Name));

        CreateMap<Department, DepartmentResponse>()
            .ForMember(b => b.BranchName, b => b.MapFrom(b => b.Branch.Name));

        CreateMap<Doctor, DoctorResponse>()
            .ForMember(d => d.DepartmentName, n => n.MapFrom(d => d.Department.Name));

        CreateMap<Floor, FloorResponse>();

        CreateMap<Patient, PatientResponse>()
            .ForMember(p => p.RoomNumber, n => n.MapFrom(n => n.Room.RoomNumber));

        CreateMap<Room, RoomResponse>()
            .ForMember(n=>n.FloorNumber, f=>f.MapFrom(n=>n.Floor.FloorNumber));

        CreateMap<Worker, WorkerResponse>()
            .ForMember(n=>n.Maney,m=>m.MapFrom(m=>m.Salary.Amount));
    }
}
