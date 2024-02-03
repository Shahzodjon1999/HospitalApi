using Hospital.Abstract;
using Hospital.InterfaceRepositoryes;

namespace Hospital.Api.Repositoryes
{
	public class MemoryRepositoryForStek<T>:IMemoryRepository<T> where T :EntityBase
	{
		Stack<T> _items = new Stack<T>();

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
			_items.Push(item);
			return true;
		}

		public bool Update(T item)
		{
			var itemArray = _items.ToArray();
			for (int i = 0; i < itemArray.Length; i++)
			{
				if (itemArray[i].Id == item.Id)
				{
					itemArray[i] = item;
					_items = new Stack<T>(itemArray.Reverse());
					return true;
				}
			}
			return false;
		}

		public bool Delete(Guid id)
		{
			var itemArray = _items.ToArray();
			for (int i = 0; i < itemArray.Length; i++)
			{
				if (itemArray[i].Id == id)
				{
					var newList = itemArray.ToList();
					newList.RemoveAt(i);
					_items = new Stack<T>(newList);
					return true;
				}
			}
			return false;
		}


	}
}
