using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Services;

public class HospitalService : IGenericService<HospitalRequest,HospitalUpdateRequest,HospitalResponse>
{
	private readonly IHospitalRepository _repository;
    private readonly IMapper _mapper;
    public HospitalService(IHospitalRepository repository,IMapper mapper)
	{
		_repository = repository;
		_mapper=mapper;
	}

	public string Create(HospitalRequest hospital)
	{
		if (string.IsNullOrEmpty(hospital.Name))
		{
			return "The name cannot be empty";
		}
		else
		{
			//var mapHospital = hospital.MapToHospital();
			var autoMap = _mapper.Map<Domen.Model.Hospital>(hospital);

            _repository.Create(autoMap);
			return $"Created new item with this ID: {autoMap.Id}";
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
		//return _mapper.Map<HospitalResponse>(mapHospitalRespository);
        return mapHospitalRespository.MapToHospitalResponse();
    }

	public IEnumerable<HospitalResponse> GetAll()
	{
        try
        {
            var getHospitals = _repository.GetAll();
            if (getHospitals != null)
				return _mapper.Map<IEnumerable<HospitalResponse>>(getHospitals);
                //return getHospitals.MapToHospitalResponsList();
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

	public string Update(HospitalUpdateRequest request)
	{
		var _item = _repository.GetById(request.Id);
		if (_item is null)
		{
			return "Paitent is not found";
		}
		var mapHospital = request.MapToHospitalUpdate();
		//var autoMap = _mapper.Map<Domen.Model.Hospital>(request);
		_repository.Update(mapHospital);
		return "Patient is updated";
	}
}
