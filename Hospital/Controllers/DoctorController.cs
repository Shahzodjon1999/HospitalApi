using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
	private readonly IGenericService<DoctorRequest,DoctorResponse> _doctorService;

	public DoctorController(IGenericService<DoctorRequest, DoctorResponse> doctorService)
	{
		_doctorService = doctorService;
	}

	[HttpGet]
	public IEnumerable<DoctorResponse> GetDoctors()
	{
		try
		{
			return _doctorService.GetAll();
		}
		catch (Exception ex)
		{
			throw new Exception($"You have exception:{ex.Message} in the Controller Method GetDoctor");
		}
	}

	[HttpGet("GetById")]
	public DoctorResponse GetDoctorById(Guid id)
	{
		try
		{
			return _doctorService.GetById(id);
		}
		catch (Exception ex)
		{
			throw new Exception($"You have exception:{ex.Message} in the Controller Method GetDoctorById");
		}
	}

	[HttpPost]
	public string Create([FromBody] DoctorRequest doctor)
	{
		try
		{
			return _doctorService.Create(doctor);
		}
		catch (Exception ex)
		{
			throw new Exception($"You have exception:{ex.Message} in the Controller Method Create");
		}
	}

	[HttpPut]
	public string Update(Guid id, DoctorRequest doctor)
	{
		try
		{
			return _doctorService.Update(id, doctor);
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
			return _doctorService.Delete(id);
		}
		catch (Exception ex)
		{
			throw new Exception($"You have exception:{ex.Message} in the Controller Method Delete");
		}
	}
}
