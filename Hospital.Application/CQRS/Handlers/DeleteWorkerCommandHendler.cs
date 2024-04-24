using Hospital.Application.CQRS.Commands.Deletes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using MediatR;

namespace Hospital.Application.CQRS.Handlers;

public class DeleteWorkerCommandHendler : IRequestHandler<DeleteWorkerCommand, string>
{
    private readonly IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _service;

    public DeleteWorkerCommandHendler(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service)
    {
        _service = service;
    }
    public Task<string> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
    {
        var result = _service.Delete(request.Id);
        return Task.FromResult(result);
    }
}
