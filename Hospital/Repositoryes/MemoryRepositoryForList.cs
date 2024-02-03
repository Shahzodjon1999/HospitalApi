using Hospital.Abstract;
using Hospital.InterfaceRepositoryes;

namespace Hospital.Api.Repositoryes
{
	public class MemoryRepositoryForList<T> : IMemoryRepository<T> where T : EntityBase
	{
		List<T> _items = new List<T>();

		public IEnumerable<T> GetAll()
		{
			return _items ;
		}

		public T GetById(Guid id)
		{
			return _items.SingleOrDefault(item => item.Id == id);
		}

		public bool Create(T item)
		{
			_items.Add(item);
			return true;
		}

		public bool Update(T item)
		{
			var existingItem = _items.SingleOrDefault(i => i.Id == item.Id);
			if (existingItem != null)
			{
				// Assuming T is a reference type
				existingItem = item;
				return true;
			}
			return false;
		}

		public bool Delete(Guid id)
		{
			var item = _items.SingleOrDefault(i => i.Id == id);
			if (item != null)
			{
				_items.Remove(item);
				return true;
			}
			return false;
		}

	}
}
