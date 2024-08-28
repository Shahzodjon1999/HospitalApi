using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.InterfaceRepositoryes;

public interface IPatientRepository:IBaseRepository<Patient>
{
    IQueryable<PatientInfoResponse> GetAllInfoPatient();
}
