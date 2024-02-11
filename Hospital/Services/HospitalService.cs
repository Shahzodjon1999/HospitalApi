using Hospital.Api.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Model;

namespace Hospital.Api.Services
{
	public class HospitalService : IGenericService<HospitalModel>
	{
		private readonly IHospitalDbRepository<HospitalModel> _mongodbRepository;

		public HospitalService(IHospitalDbRepository<HospitalModel> mongodbRepository)
		{
			_mongodbRepository = mongodbRepository;
		}

		public string Create(HospitalModel hospital)
		{
			if (string.IsNullOrEmpty(hospital.Name))
			{
				return "The name cannot be empty";
			}
			else
			{
				_mongodbRepository.Create(hospital);
				return $"Created new item with this ID: {hospital.Id}";
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

		public HospitalModel GetById(Guid id)
		{
			return _mongodbRepository.GetById(id);
		}

		public IEnumerable<HospitalModel> GetDoctors()
		{
			return _mongodbRepository.GetAll();
		}

		public string Update(Guid guid, HospitalModel doctor)
		{
			var _item = _mongodbRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_mongodbRepository.Update(guid,doctor);
			return "Doctor is updated";
		}
	}
}
