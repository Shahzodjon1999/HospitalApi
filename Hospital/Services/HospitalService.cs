using Hospital.InterfaceRepositoryes;
using Hospital.Interfaces;
using Hospital.Model;
using Hospital.Models;

namespace Hospital.Api.Services
{
	public class HospitalService : IGenericService<HospitalModel>
	{
		private readonly IGenericRepository<HospitalModel> _hospitalRepository;

		public HospitalService(IGenericRepository<HospitalModel> hospitalRepository)
		{
			_hospitalRepository = hospitalRepository;
		}

		public string Create(HospitalModel hospital)
		{
			if (string.IsNullOrEmpty(hospital.Name))
			{
				return "The name cannot be empty";
			}
			else
			{
				_hospitalRepository.Create(hospital);
				return $"Created new item with this ID: {hospital.Id}";
			}
		}

		public string Delete(Guid id)
		{
			var _item = _hospitalRepository.GetById(id);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_hospitalRepository.Delete(id);

			return "Doctor is deleted";
		}

		public HospitalModel GetById(Guid id)
		{
			return _hospitalRepository.GetById(id);
		}

		public IEnumerable<HospitalModel> GetDoctors()
		{
			return _hospitalRepository.GetAll();
		}

		public string Update(Guid guid, HospitalModel worker)
		{
			var _item = _hospitalRepository.GetById(guid);
			if (_item is null)
			{
				return "Doctor is not found";
			}
			_hospitalRepository.Update(_item, worker);
			return "Doctor is updated";
		}
	}
}
