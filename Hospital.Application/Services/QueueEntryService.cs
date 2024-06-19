using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class QueueEntryService
{
    private readonly IQueueEntryRepository _repository;
    private readonly IMapper _mapper;
    public QueueEntryService(IQueueEntryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task EnqueueAppointmentAsync(QueueEntryRequest request)
    {
        try
        {
            var queueEntry = _mapper.Map<QueueEntry>(request);
            queueEntry.EnqueueTime = DateTime.Now;

            await _repository.EnqueueAppointmentAsync(queueEntry);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<QueueEntryResponse> DequeueAppointmentAsync()
    {
        try
        {
            var queueEntry = await _repository.DequeueAppointmentAsync();

            return _mapper.Map<QueueEntryResponse>(queueEntry);
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<QueueEntryResponse>> GetQueueAsync()
    {
        try
        {
            var queueEntries = await _repository.GetQueueAsync();
            return _mapper.Map<List<QueueEntryResponse>>(queueEntries);
        }
        catch (Exception)
        {

            throw;
        }
    }
}