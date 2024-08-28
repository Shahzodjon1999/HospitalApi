using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class PositionService : IGenericService<PositionRequest, PositionUpdateRequest, PositionResponse>
{
    private readonly IPositionRepository _repository;
    private readonly IMapper _mapper;
    public PositionService(IPositionRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public string Create(PositionRequest item)
    {
        try
        {
            if (item != null)
            {
                var getMapPosition = _mapper.Map<Position>(item);
                _repository.Create(getMapPosition);
                return $"Created new item with this ID: {getMapPosition.Id}";
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

    public string Delete(Guid id)
    {
        try
        {
            var _item = _repository.GetById(id);
            if (_item is null)
            {
                return "Position is not found";
            }
            _repository.Delete(id);

            return "Position is deleted";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<PositionResponse> GetAll()
    {
        try
        {
            var getPositions = _repository.GetAll();
            if (getPositions != null)
                return _mapper.Map<IEnumerable<PositionResponse>>(getPositions);
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public PositionResponse GetById(Guid id)
    {
        try
        {
            var getPosition = _repository.GetById(id);
            if (getPosition != null)
                return _mapper.Map<PositionResponse>(getPosition);
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Update(PositionUpdateRequest item)
    {
        try
        {
            var _item = _repository.GetById(item.Id);
            if (_item is null)
            {
                return "Position is not found";
            }
            var mapToPosition = _mapper.Map<Position>(item);
            _repository.Update(mapToPosition);
            return "Position  is updated";
        }
        catch (Exception)
        {
            throw;
        }
    }
}
