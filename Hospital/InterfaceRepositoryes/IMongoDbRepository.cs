using Hospital.Abstract;

namespace Hospital.Api.InterfaceRepositoryes
{
	public interface IMongoDbRepository<T> where T : EntityBase
	{
		IEnumerable<T> GetAll();

		T GetById(Guid id);

		T Create(T item);

		Task<bool> Update(Guid id,T item);

		bool Delete(Guid id);
	}
}
