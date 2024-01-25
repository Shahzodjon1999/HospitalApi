using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Api.Services
{
	public class PatientService : IGenericService<Patient>
	{
		private readonly IGenericRepository<Patient> _patientRepository;

		public PatientService(IGenericRepository<Patient> patientRepository)
		{
			_patientRepository = patientRepository;
		}

		public string Create(Patient patient)
		{
			if (string.IsNullOrEmpty(patient.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_patientRepository.Create(patient);
				return $"Created new item with this ID: {patient.Id}";
			}
		}

		public string Delete(Guid id)
		{
			var _item = _patientRepository.GetById(id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_patientRepository.Delete(id);

			return "Doctor is deleted";
		}

		public Patient GetById(Guid id)
		{
			return _patientRepository.GetById(id);
		}

		public IEnumerable<Patient> GetDoctors()
		{
			return _patientRepository.GetAll();
		}

		public string Update(Guid guid, Patient patient)
		{
			var _item = _patientRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_patientRepository.Update(_item, patient);
			return "Doctor is updated";
		}
	}
}
