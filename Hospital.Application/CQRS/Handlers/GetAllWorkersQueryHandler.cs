using Hospital.Application.CQRS.Queries.GetAll;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using MediatR;

namespace Hospital.Application.CQRS.Handlers;

public class GetAllWorkersQueryHandler : IRequestHandler<GetAllWorkersQuery,IEnumerable<WorkerResponse>>
{
    private readonly IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> _service;

    public GetAllWorkersQueryHandler(IGenericService<WorkerRequest, WorkerUpdateRequest, WorkerResponse> service)
    {
        _service = service;
    }
    public async Task<IEnumerable<WorkerResponse>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
    {
        var workers = _service.GetAll();
        return await Task.FromResult(workers);
    }
}
