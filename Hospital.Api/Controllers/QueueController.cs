using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QueueController : ControllerBase
{
    private readonly QueueEntryService _queueService;

    public QueueController(QueueEntryService queueService)
    {
        _queueService = queueService;
    }

    // GET: api/queue
    [HttpGet]
    public async Task<ActionResult<List<QueueEntryResponse>>> GetQueue()
    {
        var queueEntries = await _queueService.GetQueueAsync();
        return Ok(queueEntries);
    }

    // POST: api/queue/enqueue
    [HttpPost("enqueue")]
    public async Task<ActionResult> EnqueueAppointment([FromBody] QueueEntryRequest request)
    {
        await _queueService.EnqueueAppointmentAsync(request);
        return Ok();
    }

    // POST: api/queue/dequeue
    [HttpPost("dequeue")]
    public async Task<ActionResult<QueueEntryResponse>> DequeueAppointment()
    {
        var queueEntry = await _queueService.DequeueAppointmentAsync();
        if (queueEntry == null)
        {
            return NotFound();
        }
        return Ok(queueEntry);
    }
}
