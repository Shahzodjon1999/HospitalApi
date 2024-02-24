using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FloorController : ControllerBase
{
	private readonly IGenericService<FloorRequest, FloorResponse> _service;

	public FloorController(IGenericService<FloorRequest, FloorResponse> service)
	{
		_service = service;
	}


	[HttpGet]
	public IEnumerable<FloorResponse> GetAll()
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
	public FloorResponse GetDoctorById(Guid id)
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
	public string Create([FromBody] FloorRequest request)
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
	public string Update(Guid id, FloorRequest request)
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
