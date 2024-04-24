using Azure.Core;
using FluentValidation;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.UpdateRequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class AppointmentController : BaseController<AppointmentRequest,AppointmentUpdateRequest, AppointmentResponse>
{
    public AppointmentController(IGenericService<AppointmentRequest, AppointmentUpdateRequest, AppointmentResponse> doctorService) : base(doctorService)
    {
    }
}
