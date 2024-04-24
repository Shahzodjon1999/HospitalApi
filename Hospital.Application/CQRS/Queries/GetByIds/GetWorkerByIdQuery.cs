using Hospital.Application.ResponseModel;
using MediatR;

namespace Hospital.Application.CQRS.Queries.GetByIds;

public record GetWorkerByIdQuery:IRequest<WorkerResponse>
{
    public Guid Id { get; set; }
}
