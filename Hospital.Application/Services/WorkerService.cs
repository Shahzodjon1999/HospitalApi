using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Services;

public class WorkerService : IGenericService<WorkerRequest,WorkerUpdateRequest,WorkerResponse>
{
	private readonly IWorkerRepository _repository;
	private readonly IMapper _mapper;
    public WorkerService(IWorkerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public string Create(WorkerRequest worker)
	{
		if (string.IsNullOrEmpty(worker.FirstName))
		{
			return "The name cannot be empty";
		}
		else
		{
			var mapWorker = worker.MapToWorker();
			_repository.Create(mapWorker);
			return $"Created new item with this ID: {mapWorker.Id}";
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

	public WorkerResponse GetById(Guid id)
	{
		var mapWorkerResponse = _repository.GetById(id);
		if (mapWorkerResponse is null)
			return null;
		return mapWorkerResponse.MapToWorkerResponse();
	}

	public IEnumerable<WorkerResponse> GetAll()
	{
		var getWorkers = _repository.GetAll();
		if (getWorkers is not null)
			//return _mapper.Map<IEnumerable<WorkerResponse>>(getWorkers);
				return getWorkers.MapToWorkerResponsList();
		return null;
	}

	public string Update(WorkerUpdateRequest request)
	{
		var _item = _repository.GetById(request.Id);
		if (_item is null)
		{
			return "Doctor is not found";
		}
		var mapWorker = request.MapToWorkerUpdate();
		_repository.Update(mapWorker);
		return "Doctor is updated";
	}
}
