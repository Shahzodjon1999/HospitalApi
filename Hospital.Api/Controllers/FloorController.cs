using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class FloorController : BaseController<FloorRequest,FloorUpdateRequest,FloorResponse>
{
    public FloorController(IGenericService<FloorRequest,FloorUpdateRequest,FloorResponse> service):base(service)
    {
        
    }
}
