using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Api.Services
{
	public class PatientService : IGenericService<Patient>
	{
		private readonly IMemoryRepository<Patient> _memoryRepository;

		public PatientService(IMemoryRepository<Patient> patientRepository)
		{
			_memoryRepository = patientRepository;
		}

		public string Create(Patient patient)
		{
			if (string.IsNullOrEmpty(patient.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_memoryRepository.Create(patient);
				return $"Created new item with this ID: {patient.Id}";
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

		public Patient GetById(Guid id)
		{
			return _memoryRepository.GetById(id);
		}

		public IEnumerable<Patient> GetDoctors()
		{
			return _memoryRepository.GetAll();
		}

		public string Update(Guid guid, Patient patient)
		{
			var _item = _memoryRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_memoryRepository.Update(patient);
			return "Doctor is updated";
		}
	}
}
