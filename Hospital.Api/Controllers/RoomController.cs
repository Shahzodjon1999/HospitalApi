using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class RoomController : BaseController<RoomRequest,RoomResponse>
{
    public RoomController(IGenericService<RoomRequest,RoomResponse> service):base(service)
    {
        
    }
}
