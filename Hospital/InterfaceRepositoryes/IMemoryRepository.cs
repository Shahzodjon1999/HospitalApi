using Hospital.Abstract;
using Hospital.Models;

namespace Hospital.InterfaceRepositoryes
{
	public interface IMemoryRepository<T> where T : EntityBase
	{
		IEnumerable<T> GetAll();

		T GetById(Guid id);

		bool Create(T item);

		bool Update(T item);

		bool Delete(Guid id);
	}
}
