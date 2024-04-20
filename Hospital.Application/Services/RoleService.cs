using AutoMapper;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.InterfaceServices;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;

namespace Hospital.Application.Services;

public class RoleService : IGenericService<RoleRequest, RoleUpdateRequest, RoleResponse>
{
    private readonly IRoleRepository _repository;
    private readonly IMapper _mapper;
    public RoleService(IMapper mapper, IRoleRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public string Create(RoleRequest item)
    {
        try
        {
            if (item != null)
            {
                var getRole = item.MapToRole();
                _repository.Create(getRole);
                return $"Created new item with this ID: {getRole.Id}";
            }
            else
            {
                return "The name cannot be empty";
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Delete(Guid id)
    {
        try
        {
            var _item = _repository.GetById(id);
            if (_item is null)
            {
                return "Role is not found";
            }
            _repository.Delete(id);

            return "Role is deleted";
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<RoleResponse> GetAll()
    {
        try
        {
            var getRoles = _repository.GetAll();
            if (getRoles != null)
                return _mapper.Map<IEnumerable<RoleResponse>>(getRoles);

            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public RoleResponse GetById(Guid id)
    {
        try
        {
            var getRole = _repository.GetById(id);
            if (getRole != null)
                return getRole.MapToRoleResponse();
            return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public string Update(RoleUpdateRequest item)
    {
        try
        {
            var _item = _repository.GetById(item.Id);
            if (_item is null)
            {
                return "Role is not found";
            }
            var mapToAppointment = item.MapToRoleUpdate();
            _repository.Update(mapToAppointment);
            return "Role is updated";
        }
        catch (Exception)
        {
            throw;
        }
    }
}
