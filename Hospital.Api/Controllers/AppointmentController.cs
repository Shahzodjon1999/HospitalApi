using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Hospital.Application.UpdateRequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class AppointmentController : BaseController<AppointmentRequest,AppointmentUpdateRequest, AppointmentResponse>
{
    private readonly  AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService,IGenericService<AppointmentRequest, AppointmentUpdateRequest, AppointmentResponse> doctorService) : base(doctorService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("check-appointment")]
    public async Task<IActionResult> CheckAppointment(Guid doctorId, DateTime appointmentDate)
    {
        var exists = await _appointmentService.CheckAppointment(doctorId, appointmentDate);
        return Ok(exists);
    }
}
