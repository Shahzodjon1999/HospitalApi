using Hospital.Api.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Models;

namespace Hospital.Api.Services
{
	public class PatientService : IGenericService<Patient>
	{
		private readonly IHospitalDbRepository<Patient> _mongodbRepository;

		public PatientService(IHospitalDbRepository<Patient> mongodbRepository)
		{
			_mongodbRepository = mongodbRepository;
		}

		public string Create(Patient patient)
		{
			if (string.IsNullOrEmpty(patient.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				_mongodbRepository.Create(patient);
				return $"Created new item with this ID: {patient.Id}";
			}
		}

		public string Delete(Guid id)
		{
			var _item = _mongodbRepository.GetById(id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_mongodbRepository.Delete(id);

			return "Doctor is deleted";
		}

		public Patient GetById(Guid id)
		{
			return _mongodbRepository.GetById(id);
		}

		public IEnumerable<Patient> GetDoctors()
		{
			return _mongodbRepository.GetAll();
		}

		public string Update(Guid guid, Patient patient)
		{
			var _item = _mongodbRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_mongodbRepository.Update(guid,patient);
			return "Doctor is updated";
		}
	}
}
