using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class PatientController : BaseController<PatientRequest,PatientUpdateRequest,PatientResponse>
{
    public PatientController(IGenericService<PatientRequest,PatientUpdateRequest,PatientResponse> service):base(service)
    {
        
    }
}
