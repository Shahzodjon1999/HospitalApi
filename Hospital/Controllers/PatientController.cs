using Hospital.Interfaces;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly IGenericService<Patient> _patientService;

		public PatientController(IGenericService<Patient> patientService)
		{
			_patientService = patientService;
		}

		[HttpGet]
		public IEnumerable<Patient> GetDoctor()
		{
			return _patientService.GetDoctors();
		}

		[HttpGet("GetById")]
		public Patient GetDoctor(Guid id)
		{
			return _patientService.GetById(id);
		}

		[HttpPost]
		public string Create([FromBody] Patient patient)
		{
			return _patientService.Create(patient);
		}

		[HttpPut]
		public string Update(Guid id, Patient doctor)
		{
			return _patientService.Update(id, doctor);
		}

		[HttpDelete]
		public string Delete(Guid id)
		{
			return _patientService.Delete(id);
		}
	}
}
