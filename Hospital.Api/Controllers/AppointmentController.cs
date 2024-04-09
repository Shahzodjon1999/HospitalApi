using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class AppointmentController : BaseController<AppointmentRequest, AppointmentResponse>
{
    public AppointmentController(IGenericService<AppointmentRequest, AppointmentResponse> doctorService) : base(doctorService)
    {
    }
}
