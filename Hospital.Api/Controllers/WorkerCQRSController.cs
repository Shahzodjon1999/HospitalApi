using Hospital.Application.CQRS.Commands.Creates;
using Hospital.Application.CQRS.Commands.Deletes;
using Hospital.Application.CQRS.Commands.Updates;
using Hospital.Application.CQRS.Queries.GetAll;
using Hospital.Application.CQRS.Queries.GetByIds;
using Hospital.Application.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class WorkerCQRSController : ControllerBase
{
    private readonly IMediator _mediator;

    public WorkerCQRSController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateWorker(CreateWorkerCommand command)
    {
        var user = await _mediator.Send(command);
        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<WorkerResponse>> GetWorkerById(Guid id)
    {
        var query = new GetWorkerByIdQuery() { Id = id };
        var client = await _mediator.Send(query);
        if (client == null)
            return NotFound();

        return Ok(client);
    }

    [HttpGet("AllWorkers")]
    public async Task<ActionResult<IEnumerable<WorkerResponse>>> GetAllWorkers()
    {
        var query = new GetAllWorkersQuery();
        var clients = await _mediator.Send(query);
        return Ok(clients);
    }

    [HttpPut]
    public async Task<ActionResult<string>> UpdateWorker(Guid id, UpdateWorkerCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteWorker([FromQuery]DeleteWorkerCommand deleteWorker)
    {
        var result = await _mediator.Send(deleteWorker);
        return Ok(result);
    }
}
