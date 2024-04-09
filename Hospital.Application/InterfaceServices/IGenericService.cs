using Hospital.Application.Entity;

namespace Hospital.Application.InterfaceServices;

public interface IGenericService<TRequest,TResponse> where TRequest : EntityBaseRequest where TResponse : EntityBaseResponse
{
	string Create(TRequest item); 

	IEnumerable<TResponse> GetAll();

	TResponse GetById(Guid id);

	string Update(Guid guid, TRequest item);

	string Delete(Guid id);
}
