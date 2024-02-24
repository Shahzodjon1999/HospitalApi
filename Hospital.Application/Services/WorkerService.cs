using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class WorkerService : IGenericService<WorkerRequest,WorkerResponse>
{
	private readonly IHospitalDbRepository<Worker> _memoryRepository;

	public WorkerService(IHospitalDbRepository<Worker> doctorRepository)
	{
		_memoryRepository = doctorRepository;
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
			_memoryRepository.Create(mapWorker);
			return $"Created new item with this ID: {mapWorker.Id}";
		}
	}

	public string Delete(Guid id)
	{
		var _item = _memoryRepository.GetById(id);
		if (_item is null)
		{
			return "Doctor is not found";
		}
		_memoryRepository.Delete(id);

		return "Doctor is deleted";
	}

	public WorkerResponse GetById(Guid id)
	{
		var mapWorkerResponse = _memoryRepository.GetById(id);
		return mapWorkerResponse.MapToWorkerResponse();
	}

	public IEnumerable<WorkerResponse> GetAll()
	{
		//return _memoryRepository.GetAll();
		return null;
	}

	public string Update(Guid guid, WorkerRequest worker)
	{
		var _item = _memoryRepository.GetById(guid);
		if (_item is null)
		{
			return "Doctor is not found";
		}
		var mapWorker = worker.MapToWorker();
		_memoryRepository.Update(guid, mapWorker);
		return "Doctor is updated";
	}
}
