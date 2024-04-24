using AutoMapper;
using Hospital.Application.CQRS.Commands.Updates;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;
using MediatR;

namespace Hospital.Application.CQRS.Handlers;

public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, string>
{
    private readonly IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _service;
    private readonly IMapper _mapper;

    public UpdateWorkerCommandHandler(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service,IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    public Task<string> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var mapWorker = _mapper.Map<WorkerUpdateRequest>(request);
        var result = _service.Update(mapWorker);
        return Task.FromResult(result);
    }
}
