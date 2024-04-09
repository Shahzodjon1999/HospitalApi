using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class PatientController : BaseController<PatientRequest,PatientResponse>
{
    public PatientController(IGenericService<PatientRequest,PatientResponse> service):base(service)
    {
        
    }
}
