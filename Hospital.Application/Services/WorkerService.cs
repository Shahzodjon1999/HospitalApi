using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class WorkerService : IGenericService<WorkerRequest,WorkerResponse>
{
	private readonly IHospitalDbRepository<Worker> _repository;

	public WorkerService(IHospitalDbRepository<Worker> repository)
	{
		_repository = repository;
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
			return getWorkers.MapToWorkerResponsList();
		return null;
	}

	public string Update(Guid guid, WorkerRequest worker)
	{
		var _item = _repository.GetById(guid);
		if (_item is null)
		{
			return "Doctor is not found";
		}
		var mapWorker = worker.MapToWorker();
		_repository.Update(guid, mapWorker);
		return "Doctor is updated";
	}
}
