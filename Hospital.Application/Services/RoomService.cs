using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class RoomService:IGenericService<RoomRequest,RoomUpdateRequest,RoomResponse>
{
	private readonly IRoomRepository _repository;
	private readonly IMapper _mapper;
    public RoomService(IRoomRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public string Create(RoomRequest item)
	{
		try
		{
			if (item != null)
			{
				var getMapRoom = item.MapToRoom();
				_repository.Create(getMapRoom);
				return $"Created new item with this ID: {getMapRoom.Id}";
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

	public RoomResponse GetById(Guid id)
	{
		try
		{
			var getRoom = _repository.GetById(id);
			if (getRoom != null)
				return _mapper.Map<RoomResponse>(getRoom);
			return null;
		}
		catch (Exception)
		{
			throw;
		}

	}

	public IEnumerable<RoomResponse> GetAll()
	{
		try
		{
			var getRooms = _repository.GetAll();
			if (getRooms != null)
				return _mapper.Map<IEnumerable<RoomResponse>>(getRooms);
			return null;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public string Update(RoomUpdateRequest item)
	{
		try
		{
			var _item = _repository.GetById(item.Id);
			if (_item is null)
			{
				return "Room is not found";
			}
			var getMapRoom = _mapper.Map<Room>(item);
			_repository.Update(getMapRoom);
			return "Room is updated";
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
				return "Room is not found";
			}
			_repository.Delete(id);

			return "Room is deleted";
		}
		catch (Exception)
		{
			throw;
		}
	}
}
