using Hospital.Interfaces;
using Hospital.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HospitalController : ControllerBase
	{
		private readonly IGenericService<HospitalModel> _hospitalService;

		public HospitalController(IGenericService<HospitalModel> hospitalService)
		{
			_hospitalService = hospitalService;
		}

		[HttpGet]
		public IEnumerable<HospitalModel> GetDoctor()
		{
			return _hospitalService.GetDoctors();
		}

		[HttpGet("GetById")]
		public HospitalModel GetDoctor(Guid id)
		{
			return _hospitalService.GetById(id);
		}

		[HttpPost]
		public string Create([FromBody] HospitalModel patient)
		{
			return _hospitalService.Create(patient);
		}

		[HttpPut]
		public string Update(Guid id, HospitalModel doctor)
		{
			return _hospitalService.Update(id, doctor);
		}

		[HttpDelete]
		public string Delete(Guid id)
		{
			return _hospitalService.Delete(id);
		}
	}
}
