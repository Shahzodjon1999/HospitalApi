using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Services;

public class ClientService : IGenericService<ClientRequest, ClientUpdateRequest, ClientResponse>
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;
    public ClientService(IClientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public string Create(ClientRequest item)
    {
        if (string.IsNullOrEmpty(item.FirstName))
        {
            return "The name cannot be empty";
        }
        else
        {
            var mapClient = _mapper.Map<Client>(item);
            _repository.Create(mapClient);
            return $"Created new item with this ID: {mapClient.Id}";
        }
    }

    public string Delete(Guid id)
    {
        var _item = _repository.GetById(id);
        if (_item is null)
        {
            return "Client is not found";
        }
        _repository.Delete(id);

        return "Client is deleted";
    }

    public IEnumerable<ClientResponse> GetAll()
    {
        var getClients = _repository.GetAll();
        if (getClients is not null)
            return _mapper.Map<IEnumerable<ClientResponse>>(getClients);
        return null;
    }

    public ClientResponse GetById(Guid id)
    {
        var mapClientResponse = _repository.GetById(id);
        if (mapClientResponse is null)
            return null;
        return _mapper.Map<ClientResponse>(mapClientResponse);
    }

    public string Update(ClientUpdateRequest item)
    {
        var _item = _repository.GetById(item.Id);
        if (_item is null)
        {
            return "Client is not found";
        }
        var mapWorker = _mapper.Map<Client>(item);
        _repository.Update(mapWorker);
        return "Client is updated";
    }
}
