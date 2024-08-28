using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerODataController : ControllerBase
    {
        private readonly IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _service;

        public WorkerODataController(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service)
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<WorkerResponse> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public ActionResult<WorkerResponse> GetById(Guid id)
        {
            var getWorker = _service.GetById(id);
            if (getWorker is not null)
                return getWorker;
            return NotFound("Didn't find Data from Database");
        }
    }
}
