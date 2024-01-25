using Hospital.InterfaceRepositoryes;
using Hospital.Models;

namespace Hospital.Repositoryes
{
	public class DoctorRepository : IGenericRepository<Doctor>
	{
	    Dictionary<Guid, Doctor> Items = new Dictionary<Guid, Doctor>();

		public IEnumerable<Doctor> GetAll()
		{
			return Items.Values;
		}

		public Doctor GetById(Guid id)
		{
			return Items.SingleOrDefault(w => w.Key == id).Value;
		}

		public bool Update(Doctor item, Doctor newItem)
		{
			item.FirstName = newItem.FirstName;
			item.LastName=newItem.LastName;
			item.Address= newItem.Address;
			item.PhoneNumber= newItem.PhoneNumber;
			return true;
		}

		public bool Create(Doctor item)
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
