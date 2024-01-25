using Hospital.InterfaceRepositoryes;
using Hospital.Models;

namespace Hospital.Api.Repositoryes
{
	public class PatientRepository : IGenericRepository<Patient>
	{
		public bool Create(Patient item)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Patient> GetAll()
		{
			throw new NotImplementedException();
		}

		public Patient GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public bool Update(Patient item, Patient newItem)
		{
			throw new NotImplementedException();
		}
	}
}
