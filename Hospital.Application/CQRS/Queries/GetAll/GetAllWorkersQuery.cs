using Hospital.Application.ResponseModel;
using MediatR;

namespace Hospital.Application.CQRS.Queries.GetAll;

public class GetAllWorkersQuery:IRequest<IEnumerable<WorkerResponse>>
{

}
