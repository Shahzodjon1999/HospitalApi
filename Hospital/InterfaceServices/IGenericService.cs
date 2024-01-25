using Hospital.Models;

namespace Hospital.Interfaces
{
	public interface IGenericService<T> where T : class
	{
		IEnumerable<T> GetDoctors();

		T GetById(Guid id);

		string Create(T worker);

		string Delete(Guid id);

		string Update(Guid guid,T worker);
	}
}
