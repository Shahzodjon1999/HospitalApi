using AutoMapper;
using Hospital.Application.CQRS.Commands.Creates;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;
using MediatR;
using NuGet.Protocol.Plugins;

namespace Hospital.Application.CQRS.Handlers;

public class CreateWorkerCommandHendler : IRequestHandler<CreateWorkerCommand, string>
{
    private readonly IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _service;
    private readonly IMapper _mapper;

    public CreateWorkerCommandHendler(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service,IMapper mapper)
    {
       _service = service;
        _mapper = mapper;
    }
    public Task<string> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = _mapper.Map<WorkerRequest>(request);
        var result =  _service.Create(worker);
        return Task.FromResult(result);
    }
}
