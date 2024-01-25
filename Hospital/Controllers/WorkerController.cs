using Hospital.Interfaces;
using Hospital.Models;
using Hospital.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkerController : ControllerBase
	{
	   private readonly IGenericService<Worker> _workerService;

        public WorkerController(IGenericService<Worker> workerService)
        {
			_workerService = workerService;
		} 

		[HttpGet]
		public IEnumerable<Worker> GetDoctor()
		{
			return _workerService.GetDoctors();
		}

		[HttpGet("GetById")]
		public Worker GetDoctor(Guid id)
		{
			return _workerService.GetById(id);
		}

		[HttpPost]
		public string Create([FromBody] Worker doctor)
		{
			return _workerService.Create(doctor);
		}

		[HttpPut]
		public string Update(Guid id,Worker doctor)
		{
			return _workerService.Update(id, doctor);
		}

		[HttpDelete]
		public string Delete(Guid id)
		{
			return _workerService.Delete(id);
		}
    }
}
