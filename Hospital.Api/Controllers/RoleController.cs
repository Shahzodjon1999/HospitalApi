using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController<RoleRequest, RoleUpdateRequest, RoleResponse>
    {
        public RoleController(IGenericService<RoleRequest, RoleUpdateRequest, RoleResponse> Service) : base(Service)
        {
        }
    }
}
