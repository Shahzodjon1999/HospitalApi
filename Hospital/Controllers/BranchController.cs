using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchController : ControllerBase
{
	private readonly IGenericService<BranchRequest, BranchResponse> _service;

	public BranchController(IGenericService<BranchRequest,BranchResponse> service)
        {
		_service = service;
	}


	[HttpGet]
	public IEnumerable<BranchResponse> GetAll()
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
	public BranchResponse GetDoctorById(Guid id)
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
	public string Create([FromBody] BranchRequest request)
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
	public string Update(Guid id, BranchRequest request)
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
