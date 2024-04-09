using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class FloorController : BaseController<FloorRequest,FloorResponse>
{
    public FloorController(IGenericService<FloorRequest,FloorResponse> service):base(service)
    {
        
    }
}
