using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;

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
			var mapPatient = patient.MapToPatient();
			_repository.Create(mapPatient);

			//if (patient.DoctorIds.Any())
			//{
			//	foreach (var doctorId in patient.DoctorIds)
			//	{
			//		var test = new DoctorPatient
			//		{
			//			DoctorId = doctorId,
			//			PatientId = mapPatient.Id
			//		};

   //                  _doctorrepo.Create(test);
   //             }
			//}

		return $"Created new item with this ID: {mapPatient.Id}";
		
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
				return _mapper.Map<IEnumerable<PatientResponse>>(getPatients);
			// return getPatients.MapToPatientResponsList();
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
			return "Doctor is not found";
		}
		var mapPatient = patient.MapToPatientUpdate();
		_repository.Update(mapPatient);
		return "Doctor is updated";
	}
}
