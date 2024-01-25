using Hospital.Interfaces;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorController : ControllerBase
	{
		private readonly IGenericService<Doctor> _doctorService;

		public DoctorController(IGenericService<Doctor> doctorService)
        {
			_doctorService = doctorService;
		}

        [HttpGet]
		public IEnumerable<Doctor> GetDoctor()
		{
			return _doctorService.GetDoctors();
		}

		[HttpGet("GetById")]
		public Doctor GetDoctor(Guid id)
		{
			return _doctorService.GetById(id);
		}

		[HttpPost]
		public string Create([FromBody] Doctor doctor)
		{
			return _doctorService.Create(doctor);
		}

		[HttpPut]
		public string Update(Guid id,Doctor doctor)
		{
			return _doctorService.Update(id, doctor);
		}

		[HttpDelete]
		public string Delete(Guid id)
		{
			return _doctorService.Delete(id);
		}
	}
}
