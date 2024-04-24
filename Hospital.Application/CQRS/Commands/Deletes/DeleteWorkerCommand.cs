using MediatR;

namespace Hospital.Application.CQRS.Commands.Deletes;

public class DeleteWorkerCommand:IRequest<string>
{
    public Guid Id { get; set; }
}
