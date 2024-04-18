using Hospital.Domen.Abstract;

namespace Hospital.Application.InterfaceRepositoryes;

public interface IBaseRepository<T> where T : EntityBase
{
	IQueryable<T> GetAll();

	T GetById(Guid id);

	T Create(T item);

	bool Update(T item);

	bool Delete(Guid id);
}
