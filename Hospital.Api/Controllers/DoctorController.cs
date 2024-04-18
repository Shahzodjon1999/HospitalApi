using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class DoctorController : BaseController<DoctorRequest,DoctorUpdateRequest,DoctorResponse>
{
    public DoctorController(IGenericService<DoctorRequest,DoctorUpdateRequest,DoctorResponse> service):base(service)
    {
        
    }
}
