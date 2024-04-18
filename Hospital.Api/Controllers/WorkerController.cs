using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
public class WorkerController : BaseController<WorkerRequest,WorkerUpdateRequest, WorkerResponse>
{
    public WorkerController(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service):base(service)
    {
        
    }
}
