using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class FloorService:IGenericService<FloorRequest,FloorUpdateRequest,FloorResponse>
{
	private readonly IFloorRepository _repository;

	private readonly IMapper _mapper;


    public FloorService(IFloorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public string Create(FloorRequest item)
	{
		try
		{
			if (item != null)
			{
				var getMapFloor =_mapper.Map<Floor>(item);
				_repository.Create(getMapFloor);
				return $"Created new item with this ID: {getMapFloor.Id}";
			}
			else
			{
				return "The name cannot be empty";
			}
		}
		catch (Exception)
		{
			throw;
		}
	}

	public FloorResponse GetById(Guid id)
	{
		try
		{
			var getFloors = _repository.GetById(id);
			if (getFloors != null)
				return _mapper.Map<FloorResponse>(getFloors);
			return null;
		}
		catch (Exception)
		{
			throw;
		}

	}

	public IEnumerable<FloorResponse> GetAll()
	{
		try
		{
			var getFloors = _repository.GetAll();
			if (getFloors != null)
				return _mapper.Map<IEnumerable<FloorResponse>>(getFloors);
			return null;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public string Update(FloorUpdateRequest updateRequest)
	{
		try
		{
			var _item = _repository.GetById(updateRequest.Id);
			if (_item is null)
			{
				return "Floor is not found";
			}
			var getMapFloor = _mapper.Map<Floor>(updateRequest);
			_repository.Update(getMapFloor);
			return "Floor is updated";
		}
		catch (Exception)
		{
			throw;
		}
	}

	public string Delete(Guid id)
	{
		try
		{
			var _item = _repository.GetById(id);
			if (_item is null)
			{
				return "Floor is not found";
			}
			_repository.Delete(id);

			return "Floor is deleted";
		}
		catch (Exception)
		{
			throw;
		}
	}
}
