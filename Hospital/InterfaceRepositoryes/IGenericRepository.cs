using Hospital.Models;

namespace Hospital.InterfaceRepositoryes
{
	public interface IGenericRepository<T> where T : class
	{
		IEnumerable<T> GetAll();

		T GetById(Guid id);

		bool Create(T item);

		bool Update(T item,T newItem);

		bool Delete(Guid id);
	}
}
