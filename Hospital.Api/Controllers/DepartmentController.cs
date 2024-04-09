using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class DepartmentController : BaseController<DepartmentRequest, DepartmentResponse>
{
    public DepartmentController(IGenericService<DepartmentRequest, DepartmentResponse> service):base(service)
    {
    }
}
