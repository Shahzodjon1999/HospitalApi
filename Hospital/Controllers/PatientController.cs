using Hospital.Api.InterfaceServices;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly IGenericService<PatientRequest, PatientResponse> _patientService;

		public PatientController(IGenericService<PatientRequest, PatientResponse> patientService)
		{
			_patientService = patientService;
		}

		[HttpGet]
		public IEnumerable<PatientResponse> GetAll()
		{
			return _patientService.GetAll();
		}

		[HttpGet("GetById")]
		public PatientResponse GetDoctor(Guid id)
		{
			return _patientService.GetById(id);
		}

		[HttpPost]
		public string Create([FromBody] PatientRequest patient)
		{
			return _patientService.Create(patient);
		}

		[HttpPut]
		public string Update(Guid id, PatientRequest doctor)
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
