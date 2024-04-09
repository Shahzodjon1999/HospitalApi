using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Services;

public class HospitalService : IGenericService<HospitalRequest,HospitalResponse>
{
	private readonly IHospitalDbRepository<Domen.Model.Hospital> _repository;

	public HospitalService(IHospitalDbRepository<Domen.Model.Hospital> repository)
	{
		_repository = repository;
	}

	public string Create(HospitalRequest hospital)
	{
		if (string.IsNullOrEmpty(hospital.Name))
		{
			return "The name cannot be empty";
		}
		else
		{
			var mapHospital = hospital.MapToHospital();
			_repository.Create(mapHospital);
			return $"Created new item with this ID: {mapHospital.Id}";
		}
	}

	public string Delete(Guid id)
	{
		var _item = _repository.GetById(id);
		if (_item is null)
		{
			return "Paitent is not found";
		}
		_repository.Delete(id);

		return "Paitent is deleted";
	}

	public HospitalResponse GetById(Guid id)
	{
		var mapHospitalRespository = _repository.GetById(id);
		if (mapHospitalRespository is null)
			return null;
		return mapHospitalRespository.MapToHospitalResponse();
	}

	public IEnumerable<HospitalResponse> GetAll()
	{
        try
        {
            var getHospitals = _repository.GetAll();
            if (getHospitals != null)
                return getHospitals.MapToHospitalResponsList();
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

	public string Update(Guid guid, HospitalRequest request)
	{
		var _item = _repository.GetById(guid);
		if (_item is null)
		{
			return "Paitent is not found";
		}
		var mapHospital = request.MapToHospital();
		_repository.Update(guid, mapHospital);
		return "Patient is updated";
	}
}
