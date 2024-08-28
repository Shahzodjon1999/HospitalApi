using Hospital.Application.RequestModel;
using Hospital.Application.RequestModelUpdate;
using Hospital.Application.ResponseModel;
using Hospital.Application.UpdateRequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping;

public static class RoleMap
{
    public static Role MapToRole(this RoleRequest request)
    {
        return new Role()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };
    }
    public static RoleResponse MapToRoleResponse(this Role role)
    {
        return new RoleResponse()
        {
            Name = role.Name,
            Id= role.Id
        };
    }
    public static Role MapToRoleUpdate(this RoleUpdateRequest request)
    {
        return new Role()
        {
            Id = request.Id,
            Name= request.Name,
        };
    }
}
