using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalController : ControllerBase
{
	private readonly IGenericService<HospitalRequest,HospitalResponse> _hospitalService;

	public HospitalController(IGenericService<HospitalRequest, HospitalResponse> hospitalService)
	{
		_hospitalService = hospitalService;
	}

	[HttpGet]
	public IEnumerable<HospitalResponse> GetDoctor()
	{
		return _hospitalService.GetAll();
	}

	[HttpGet("GetById")]
	public HospitalResponse GetDoctor(Guid id)
	{
		return _hospitalService.GetById(id);
	}

	[HttpPost]
	public string Create([FromBody] HospitalRequest patient)
	{
		return _hospitalService.Create(patient);
	}

	[HttpPut]
	public string Update(Guid id, HospitalRequest doctor)
	{
		return _hospitalService.Update(id, doctor);
	}

	[HttpDelete]
	public string Delete(Guid id)
	{
		return _hospitalService.Delete(id);
	}
}
