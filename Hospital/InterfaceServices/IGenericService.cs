using Hospital.Abstract;
using Hospital.Models;

namespace Hospital.Interfaces
{
	public interface IGenericService<T> where T : EntityBase
	{
		IEnumerable<T> GetDoctors();

		T GetById(Guid id);

		string Create(T worker);

		string Delete(Guid id);

		string Update(Guid guid,T worker);
	}
}
