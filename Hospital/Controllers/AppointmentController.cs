using Hospital.Api.InterfaceServices;
using Hospital.Api.RequestModel;
using Hospital.Api.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
		private readonly IGenericService<AppointmentRequest,AppointmentResponse> _doctorService;

		public AppointmentController(IGenericService<AppointmentRequest, AppointmentResponse> doctorService)
		{
			_doctorService = doctorService;
		}

		[HttpGet]
		public IEnumerable<AppointmentResponse> GetDoctors()
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
		public AppointmentResponse GetDoctorById(Guid id)
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
		public string Create([FromBody] AppointmentRequest request)
		{
			try
			{
				return _doctorService.Create(request);
			}
			catch (Exception ex)
			{
				throw new Exception($"You have exception:{ex.Message} in the Controller Method Create");
			}
		}

		[HttpPut]
		public string Update(Guid id, AppointmentRequest request)
		{
			try
			{
				return _doctorService.Update(id, request);
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
