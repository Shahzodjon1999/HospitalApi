using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
	private readonly IGenericService<WorkerRequest,WorkerResponse> _workerService;

	public WorkerController(IGenericService<WorkerRequest, WorkerResponse> workerService)
	{
		_workerService = workerService;
	}

	[HttpGet]
	public IEnumerable<WorkerResponse> GetDoctor()
	{
		return _workerService.GetAll();
	}

	[HttpGet("GetById")]
	public WorkerResponse GetDoctor(Guid id)
	{
		return _workerService.GetById(id);
	}

	[HttpPost]
	public string Create([FromBody] WorkerRequest doctor)
	{
		return _workerService.Create(doctor);
	}

	[HttpPut]
	public string Update(Guid id, WorkerRequest doctor)
	{
		return _workerService.Update(id, doctor);
	}

	[HttpDelete]
	public string Delete(Guid id)
	{
		return _workerService.Delete(id);
	}
}
