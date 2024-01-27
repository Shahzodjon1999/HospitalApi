using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Model;
using Hospital.Models;

namespace Hospital.Api.Services
{
	public class HospitalService : IGenericService<HospitalModel>
	{
		private readonly IMemoryRepository<HospitalModel> _memoryRepository;

		public HospitalService(IMemoryRepository<HospitalModel> hospitalRepository)
		{
			_memoryRepository = hospitalRepository;
		}

		public string Create(HospitalModel hospital)
		{
			if (string.IsNullOrEmpty(hospital.Name))
			{
				return "The name cannot be empty";
			}
			else
			{
				_memoryRepository.Create(hospital);
				return $"Created new item with this ID: {hospital.Id}";
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

		public HospitalModel GetById(Guid id)
		{
			return _memoryRepository.GetById(id);
		}

		public IEnumerable<HospitalModel> GetDoctors()
		{
			return _memoryRepository.GetAll();
		}

		public string Update(Guid guid, HospitalModel doctor)
		{
			var _item = _memoryRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_memoryRepository.Update(doctor);
			return "Doctor is updated";
		}
	}
}
