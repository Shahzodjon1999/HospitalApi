using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Services
{
	public class WorkerService:IGenericService<Worker>
	{
		private readonly IGenericRepository<Worker> _workerRepository;

		public WorkerService(IGenericRepository<Worker> doctorRepository)
		{
			_workerRepository = doctorRepository;
		}

		public string Create(Worker worker)
		{
			if (string.IsNullOrEmpty(worker.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_workerRepository.Create(worker);
				return $"Created new item with this ID: {worker.Id}";
			}
		}

		public string Delete(Guid id)
		{
			var _item = _workerRepository.GetById(id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_workerRepository.Delete(id);

			return "Doctor is deleted";
		}

		public Worker GetById(Guid id)
		{
			return _workerRepository.GetById(id);
		}

		public IEnumerable<Worker> GetDoctors()
		{
			return _workerRepository.GetAll();
		}

		public string Update(Guid guid,Worker worker)
		{
			var _item = _workerRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_workerRepository.Update(_item, worker);
			return "Doctor is updated";
		}
    }
}
