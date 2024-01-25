using Hospital.InterfaceRepositoryes;
using Hospital.Models;

namespace Hospital.Repositoryes
{
	public class WorkerRepository : IGenericRepository<Worker>
	{
		static Dictionary<Guid, Worker> Items = new Dictionary<Guid, Worker>();

		public IEnumerable<Worker> GetAll()
		{
			return Items.Values;
		}

		public Worker GetById(Guid id)
		{
			return Items.SingleOrDefault(w => w.Key == id).Value;
		}

		public bool Update(Worker item, Worker newItem)
		{
			item.FirstName = newItem.FirstName;
			item.LastName = newItem.LastName;
			item.Address = newItem.Address;
			item.PhoneNumber = newItem.PhoneNumber;
			return true;
		}

		public bool Create(Worker item)
		{
			if (string.IsNullOrEmpty(item.FirstName))
			{
				return false;
			}
			else
			{
				Items.Add(item.Id, item);
				return true;
			}
		}

		public bool Delete(Guid id)
		{
			Items.Remove(id);

			return true;
		}
	}
}
