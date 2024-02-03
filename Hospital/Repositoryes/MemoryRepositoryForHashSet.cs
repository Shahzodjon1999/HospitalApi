using Hospital.Abstract;
using Hospital.InterfaceRepositoryes;

namespace Hospital.Api.Repositoryes
{
	public class MemoryRepositoryForHashSet<T>:IMemoryRepository<T> where T : EntityBase
	{
		HashSet<T> _items = new HashSet<T>();

		public IEnumerable<T> GetAll()
		{
			return _items;
		}

		public T GetById(Guid id)
		{
			return _items.FirstOrDefault(item => item.Id == id);
		}

		public bool Create(T item)
		{
			return _items.Add(item);
		}

		public bool Update(T item)
		{
			if (_items.Remove(item))
			{
				_items.Add(item);
				return true;
			}
			return false;
		}

		public bool Delete(Guid id)
		{
			var item = _items.FirstOrDefault(i => i.Id == id);
			if (item != null)
			{
				_items.Remove(item);
				return true;
			}
			return false;
		}

	}
}
