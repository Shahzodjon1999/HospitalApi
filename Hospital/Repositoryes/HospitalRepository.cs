using Hospital.InterfaceRepositoryes;
using Hospital.Model;

namespace Hospital.Api.Repositoryes
{
	public class HospitalRepository : IGenericRepository<HospitalModel>
	{
		public bool Create(HospitalModel item)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<HospitalModel> GetAll()
		{
			throw new NotImplementedException();
		}

		public HospitalModel GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public bool Update(HospitalModel item, HospitalModel newItem)
		{
			throw new NotImplementedException();
		}
	}
}
