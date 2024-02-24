using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services
{
	public class DoctorService : IGenericService<DoctorRequest,DoctorResponse>
	{
		private readonly IHospitalDbRepository<Doctor> _memoryRepository;

		public DoctorService(IHospitalDbRepository<Doctor> doctorRepository)
		{
			_memoryRepository = doctorRepository;
		}

		public string Create(DoctorRequest doctor)
		{
			if (string.IsNullOrEmpty(doctor.FirstName))
			{
				return "The name cannot be empty";
			}
			else
			{
				var mapDoctor = doctor.MapToDoctor();
				_memoryRepository.Create(mapDoctor);
				return $"Created new item with this ID: {mapDoctor.Id}";
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

		public DoctorResponse GetById(Guid id)
		{
			try
			{
				var mapDoctorResponse = _memoryRepository.GetById(id);
				return mapDoctorResponse.MapToDoctorResponse();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IEnumerable<DoctorResponse> GetAll()
		{
			//return _memoryRepository.GetAll();
			return null;
		}

		public string Update(Guid guid, DoctorRequest doctor)
		{
			var _item = _memoryRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			var mapDoctor = doctor.MapToDoctor();
			_memoryRepository.Update(guid, mapDoctor);
			return "Doctor is updated";
		}
	}
}
