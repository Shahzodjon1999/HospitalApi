using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionController : BaseController<PositionRequest, PositionUpdateRequest, PositionResponse>
{
    public PositionController(IGenericService<PositionRequest, PositionUpdateRequest, PositionResponse> service) : base(service)
    {
    }
}
