using Hospital.Api.InterfaceRepositoryes;
using Hospital.Api.InterfaceServices;
using Hospital.Api.Mapping;
using Hospital.Api.Model;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;

namespace Hospital.Api.Services
{
	public class PatientService : IGenericService<PatientRequest,PatientResponse>
	{
		private readonly IHospitalDbRepository<Patient> _mongodbRepository;

		public PatientService(IHospitalDbRepository<Patient> mongodbRepository)
		{
			_mongodbRepository = mongodbRepository;
		}

		public string Create(PatientRequest patient)
		{
			if (string.IsNullOrEmpty(patient.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				var mapPatient = patient.MapToPatient();
				_mongodbRepository.Create(mapPatient);
				return $"Created new item with this ID: {mapPatient.Id}";
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

		public PatientResponse GetById(Guid id)
		{
			try
			{
				var mapPatientResponse = _mongodbRepository.GetById(id);
				return mapPatientResponse.MapToPatinetResponse();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IEnumerable<PatientResponse> GetAll()
		{
			//return _mongodbRepository.GetAll();
			return null;
		}

		public string Update(Guid guid, PatientRequest patient)
		{
			var _item = _mongodbRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			var mapPatient = patient.MapToPatient();
			_mongodbRepository.Update(guid,mapPatient);
			return "Doctor is updated";
		}
	}
}
