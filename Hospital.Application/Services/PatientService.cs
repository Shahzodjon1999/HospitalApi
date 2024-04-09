using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class PatientService : IGenericService<PatientRequest,PatientResponse>
{
	private readonly IHospitalDbRepository<Patient> _repository;

	public PatientService(IHospitalDbRepository<Patient> repository)
	{
		_repository = repository;
	}

	public string Create(PatientRequest patient)
	{
		if (string.IsNullOrEmpty(patient.FirstName))
		{
			return "The name cannot be empty";
		}
		else
		{
			var mapPatient = patient.MapToPatient();
			_repository.Create(mapPatient);
			return $"Created new item with this ID: {mapPatient.Id}";
		}
	}

	public string Delete(Guid id)
	{
		var _item = _repository.GetById(id);
		if (_item is null)
		{
			return "Doctor is not found";
		}
		_repository.Delete(id);

		return "Doctor is deleted";
	}

	public PatientResponse GetById(Guid id)
	{
		try
		{
			var mapPatientResponse = _repository.GetById(id);
			if (mapPatientResponse is null)
				return null;
			return mapPatientResponse.MapToPatinetResponse();
		}
		catch (Exception)
		{

			throw;
		}
	}

	public IEnumerable<PatientResponse> GetAll()
	{
        try
        {
            var getPatients = _repository.GetAll();
            if (getPatients != null)
                return getPatients.MapToPatientResponsList();
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

	public string Update(Guid guid, PatientRequest patient)
	{
		var _item = _repository.GetById(guid);
		if (_item is null)
		{
			return "Doctor is not found";
		}
		var mapPatient = patient.MapToPatient();
		_repository.Update(guid,mapPatient);
		return "Doctor is updated";
	}
}
