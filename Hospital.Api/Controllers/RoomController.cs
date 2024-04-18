using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class RoomController : BaseController<RoomRequest,RoomUpdateRequest,RoomResponse>
{
    public RoomController(IGenericService<RoomRequest,RoomUpdateRequest,RoomResponse> service):base(service)
    {
        
    }
}
