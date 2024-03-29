﻿using Hospital.Domen.Abstract;

namespace Hospital.Application.InterfaceRepositoryes;

public interface IHospitalDbRepository<T> where T : EntityBase
{
	IQueryable<T> GetAll();

	T GetById(Guid id);

	T Create(T item);

	bool Update(Guid id, T item);

	bool Delete(Guid id);
}
