using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

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
			var mapWorker = _mapper.Map<Worker>(worker);
			_repository.Create(mapWorker);
			return $"Created new item with this ID: {mapWorker.Id}";
		}
	}

	public string Delete(Guid id)
	{
		var _item = _repository.GetById(id);
		if (_item is null)
		{
			return "Worker is not found";
		}
		_repository.Delete(id);

		return "Worker is deleted";
	}

	public WorkerResponse GetById(Guid id)
	{
		var mapWorkerResponse = _repository.GetById(id);
		if (mapWorkerResponse is null)
			return null;
		return _mapper.Map<WorkerResponse>(mapWorkerResponse);
	}

	public IEnumerable<WorkerResponse> GetAll()
	{
		var getWorkers = _repository.GetAll();
		if (getWorkers is not null)
			return _mapper.Map<IEnumerable<WorkerResponse>>(getWorkers);
		return null;
	}

	public string Update(WorkerUpdateRequest request)
	{
		var _item = _repository.GetById(request.Id);
		if (_item is null)
		{
			return "Worker is not found";
		}
		var mapWorker = _mapper.Map<Worker>(request);
		_repository.Update(mapWorker);
		return "Worker is updated";
	}
}
