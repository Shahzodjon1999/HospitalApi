using Hospital.Interfaces;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Numerics;
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
		public IEnumerable<Doctor> GetDoctors()
		{
			try
			{
				return _doctorService.GetDoctors();
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller Method GetDoctor");
			}
		}

		[HttpGet("GetById")]
		public Doctor GetDoctorById(Guid id)
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
		public string Create([FromBody] Doctor doctor)
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
		public string Update(Guid id,Doctor doctor)
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
}
