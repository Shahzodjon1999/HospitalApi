using Hospital.Application.Entity;

namespace Hospital.Application.InterfaceServices;

public interface IGenericService<TRequest,TUpdateRequest,TResponse> where TRequest : EntityBaseRequest where TUpdateRequest:EntityBaseUpdateRequest where TResponse : EntityBaseResponse
{
	string Create(TRequest item); 

	IEnumerable<TResponse> GetAll();

	TResponse GetById(Guid id);

	string Update(TUpdateRequest item);

	string Delete(Guid id);
}
