using Hospital.Api.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Services
{
	public class DoctorService : IGenericService<Doctor>
	{
		private readonly IMongoDbRepository<Doctor> _memoryRepository;

		public DoctorService(IMongoDbRepository<Doctor> doctorRepository)
		{
			_memoryRepository = doctorRepository;
		}
		/// <summary>
		/// This is for create Doctor
		/// </summary>
		/// <param name="doctor">worker from Worker model</param>
		/// <returns>return string</returns>
		public  string Create(Doctor doctor)
		{
			if (string.IsNullOrEmpty(doctor.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_memoryRepository.Create(doctor);
				return $"Created new item with this ID: {doctor.Id}";
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

		public Doctor GetById(Guid id)
		{
			return  _memoryRepository.GetById(id);
		}

		public IEnumerable<Doctor> GetDoctors()
		{
			return _memoryRepository.GetAll();
		}

		public string Update(Guid guid, Doctor doctor)
		{
			var _item = _memoryRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_memoryRepository.Update(guid,doctor);
			return "Doctor is updated";
		}
	}
}
