using FluentValidation;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class HospitalController : BaseController<HospitalRequest, HospitalUpdateRequest, HospitalResponse>
{
    public HospitalController(IGenericService<HospitalRequest, HospitalUpdateRequest, HospitalResponse> service) : base(service)
    {
        
    }
}
