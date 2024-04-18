using Hospital.Application.InterfaceRepositoryes;
using Hospital.Domen.Abstract;
using Hospital.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
{
	protected readonly HospitalContext _context;

	protected readonly DbSet<T> _dbSet;

	public BaseRepository(HospitalContext context)
	{
		_context = context;
		_dbSet = context.Set<T>();
	}

	public T Create(T item)
	{
		try
		{
            _dbSet.Add(item);
            _context.SaveChanges();
            return item;
        }
		catch (Exception)
		{

			throw;
		}
	}

	public bool Delete(Guid id)
	{
		try
		{
            var item = GetById(id);
            _dbSet.Remove(item);
            _context.SaveChanges();
            return true;
        }
		catch (Exception)
		{

			throw;
		}
	}

	public virtual IQueryable<T> GetAll()
	{
		try
		{
            return _dbSet.AsQueryable();
        }
		catch (Exception)
		{
			throw;
		}
		
	}

	public T GetById(Guid id)
	{
		try
		{
            return _dbSet.FirstOrDefault(p => p.Id == id);
        }
		catch (Exception)
		{

			throw;
		}
		
	}

	public bool Update(T item)
	{
		try
		{
            var itemResult = GetById(item.Id);

            _context.Entry(itemResult).State = EntityState.Detached;
            item.Id = item.Id;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
		catch (Exception)
		{

			throw;
		}
	}
}
