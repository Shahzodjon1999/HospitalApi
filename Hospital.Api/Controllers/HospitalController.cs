using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class HospitalController : BaseController<HospitalRequest,HospitalResponse>
{
    public HospitalController(IGenericService<HospitalRequest,HospitalResponse> service):base(service)
    {
        
    }
}
