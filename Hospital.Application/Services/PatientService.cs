using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class PatientService : IGenericService<PatientRequest,PatientUpdateRequest,PatientResponse>
{
	private readonly IPatientRepository _repository;

	private readonly IMapper _mapper;

    public PatientService(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public string Create(PatientRequest patient)
	{
		if (string.IsNullOrEmpty(patient.FirstName))
		{
			return "The name cannot be empty";
		}
			var mapPatient = _mapper.Map<Patient>(patient);
			_repository.Create(mapPatient);
		return $"Created new item with this ID: {mapPatient.Id}";
		
	}

	public string Delete(Guid id)
	{
		var _item = _repository.GetById(id);
		if (_item is null)
		{
			return "Patient is not found";
		}
		_repository.Delete(id);

		return "Patient is deleted";
	}

	public PatientResponse GetById(Guid id)
	{
		try
		{
			var mapPatientResponse = _repository.GetById(id);
			if (mapPatientResponse is null)
				return null;
			return _mapper.Map<PatientResponse>(mapPatientResponse);
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
				return _mapper.Map<IEnumerable<PatientResponse>>(getPatients);
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

	public string Update(PatientUpdateRequest patient)
	{
		var _item = _repository.GetById(patient.Id);
		if (_item is null)
		{
			return "Patient is not found";
		}
		var mapPatient = _mapper.Map<Patient>(patient);
		mapPatient.RoomID = _item.RoomID;
		_repository.Update(mapPatient);
		return "Patient is updated";
	}

	public IEnumerable<PatientInfoResponse> GetAllInfoPatient()
	{
        try
        {
            var getInfoPatients = _repository.GetAllInfoPatient();
            if (getInfoPatients != null)
                return _mapper.Map<IEnumerable<PatientInfoResponse>>(getInfoPatients);
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
