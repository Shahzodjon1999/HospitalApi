﻿using Hospital.Api.InterfaceServices;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IGenericService<DepartmentRequest, DepartmentResponse> _service;

		public DepartmentController(IGenericService<DepartmentRequest, DepartmentResponse> service)
		{
			_service = service;
		}


		[HttpGet]
		public IEnumerable<DepartmentResponse> GetAll()
		{
			try
			{
				return _service.GetAll();
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller");
			}
		}

		[HttpGet("GetById")]
		public DepartmentResponse GetDoctorById(Guid id)
		{
			try
			{
				return _service.GetById(id);
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller Method ");
			}
		}

		[HttpPost]
		public string Create([FromBody] DepartmentRequest request)
		{
			try
			{
				return _service.Create(request);
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller Method Create");
			}
		}

		[HttpPut]
		public string Update(Guid id, DepartmentRequest request)
		{
			try
			{
				return _service.Update(id, request);
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller Method Update");
			}
		}

		[HttpDelete]
		public string Delete(Guid id)
		{
			try
			{
				return _service.Delete(id);
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller Method Delete");
			}
		}
	}
}
