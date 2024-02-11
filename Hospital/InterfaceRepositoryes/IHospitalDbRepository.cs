using Hospital.Abstract;

namespace Hospital.Api.InterfaceRepositoryes
{
	public interface IHospitalDbRepository<T> where T : EntityBase
	{
		IEnumerable<T> GetAll();

		T GetById(Guid id);

		T Create(T item);

		bool Update(Guid id, T item);

		bool Delete(Guid id);
	}
}
