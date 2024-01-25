using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Services
{
	public class DoctorService : IGenericService<Doctor>
	{
		private readonly IGenericRepository<Doctor> _doctorRepository;

		public DoctorService(IGenericRepository<Doctor> doctorRepository)
        {
			_doctorRepository = doctorRepository;
		}

        public  string Create(Doctor worker)
		{
			if (string.IsNullOrEmpty(worker.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_doctorRepository.Create(worker);
				return $"Created new item with this ID: {worker.Id}";
			}
		}

		public string Delete(Guid id)
		{
			var _item = _doctorRepository.GetById(id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_doctorRepository.Delete(id);

			return "Doctor is deleted";
		}

		public Doctor GetById(Guid id)
		{
			return  _doctorRepository.GetById(id);
		}

		public IEnumerable<Doctor> GetDoctors()
		{
			return _doctorRepository.GetAll();
		}

		public string Update(Guid guid, Doctor worker)
		{
			var _item = _doctorRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_doctorRepository.Update(_item,worker);
			return "Doctor is updated";
		}
	}
}
