using FluentValidation;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class DepartmentController : BaseController<DepartmentRequest,DepartmentUpdateRequest, DepartmentResponse>
{
    public DepartmentController(IGenericService<DepartmentRequest, DepartmentUpdateRequest, DepartmentResponse> service) : base(service)
    {
    }
}
