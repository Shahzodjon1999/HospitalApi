using AutoMapper;
using Hospital.Application.CQRS.Queries.GetByIds;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using MediatR;

namespace Hospital.Application.CQRS.Handlers;

public class GetWorkerQueryHandler : IRequestHandler<GetWorkerByIdQuery, WorkerResponse>
{
    private readonly IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _service;
    public GetWorkerQueryHandler(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service)
    {
        _service = service;
    }
    public async Task<WorkerResponse> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
    {
        var worker =_service.GetById(request.Id);
        return  await Task.FromResult(worker);
    }
}
