using Hospital.Api.Abstract;
using Hospital.Api.Infrastructure.Database;
using Hospital.Api.InterfaceRepositoryes;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.Repositories
{
	public class HospitalDbRepository<T> : IHospitalDbRepository<T> where T : EntityBase
	{
		protected readonly HospitalContext _context;

		protected readonly DbSet<T> _dbSet;

		public HospitalDbRepository(HospitalContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public T Create(T item)
		{
			_dbSet.Add(item);
			_context.SaveChanges();
			return item;
		}

		public bool Delete(Guid id)
		{
			var item = GetById(id);
			_dbSet.Remove(item);
			_context.SaveChanges();
			return true;
		}

		public IQueryable<T> GetAll()
		{
			return _dbSet.AsQueryable();
		}

		public T GetById(Guid id)
		{
			return _dbSet.FirstOrDefault(p => p.Id == id);
		}

		public bool Update(Guid id, T item)
		{
			var itemResult = GetById(id);

			_context.Entry(itemResult).State = EntityState.Detached;
			item.Id = id;
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();

			return true;
		}
	}
}
