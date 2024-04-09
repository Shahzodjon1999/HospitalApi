using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class DoctorController : BaseController<DoctorRequest,DoctorResponse>
{
    public DoctorController(IGenericService<DoctorRequest,DoctorResponse> service):base(service)
    {
        
    }
}
