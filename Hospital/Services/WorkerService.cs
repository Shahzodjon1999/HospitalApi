using Hospital.Api.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Services
{
	public class WorkerService:IGenericService<Worker>
	{
		private readonly IHospitalDbRepository<Worker> _memoryRepository;

		public WorkerService(IHospitalDbRepository<Worker> doctorRepository)
		{
			_memoryRepository = doctorRepository;
		}

		public string Create(Worker worker)
		{
			if (string.IsNullOrEmpty(worker.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_memoryRepository.Create(worker);
				return $"Created new item with this ID: {worker.Id}";
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

		public Worker GetById(Guid id)
		{
			return _memoryRepository.GetById(id);
		}

		public IEnumerable<Worker> GetDoctors()
		{
			return _memoryRepository.GetAll();
		}

		public string Update(Guid guid,Worker worker)
		{
			var _item = _memoryRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_memoryRepository.Update(guid,worker);
			return "Doctor is updated";
		}
    }
}
