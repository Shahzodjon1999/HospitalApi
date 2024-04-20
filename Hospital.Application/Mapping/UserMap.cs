using Hospital.Application.RequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping
{
    public static class UserMap
    {
        public static Auth MapToUser(this AuthRequest userRequest)
        {
            return new Auth
            {
                Id = Guid.NewGuid(),
                Login = userRequest.Login,
                Password= userRequest.Password,
                IsBlocked = userRequest.IsBlocked,
                RoleId = userRequest.RoleId,
                WorkerId = userRequest.WorkerId,
            };
        }
    }
}
