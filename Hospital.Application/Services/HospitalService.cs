﻿using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Services;

public class HospitalService : IGenericService<HospitalRequest,HospitalResponse>
{
	private readonly IHospitalDbRepository<Domen.Model.Hospital> _mongodbRepository;

	public HospitalService(IHospitalDbRepository<Domen.Model.Hospital> mongodbRepository)
	{
		_mongodbRepository = mongodbRepository;
	}

	public string Create(HospitalRequest hospital)
	{
		if (string.IsNullOrEmpty(hospital.Name))
		{
			return "The name cannot be empty";
		}
		else
		{
			var mapHospital = hospital.MapToHospital();
			_mongodbRepository.Create(mapHospital);
			return $"Created new item with this ID: {mapHospital.Id}";
		}
	}

	public string Delete(Guid id)
	{
		var _item = _mongodbRepository.GetById(id);
		if (_item is null)
		{
			return "Paitent is not found";
		}
		_mongodbRepository.Delete(id);

		return "Paitent is deleted";
	}

	public HospitalResponse GetById(Guid id)
	{
		var mapHospitalRespository = _mongodbRepository.GetById(id);
		return mapHospitalRespository.MapToHospitalResponse();
	}

	public IEnumerable<HospitalResponse> GetAll()
	{
		//return _mongodbRepository.GetAll();
		return null;
	}

	public string Update(Guid guid, HospitalRequest request)
	{
		var _item = _mongodbRepository.GetById(guid);
		if (_item is null)
		{
			return "Paitent is not found";
		}
		var mapHospital = request.MapToHospital();
		_mongodbRepository.Update(guid, mapHospital);
		return "Patient is updated";
	}
}
