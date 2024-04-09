using Hospital.Application.RequestModel;
using Hospital.Domen.Model;

namespace Hospital.Application.Mapping
{
    public static class UserMap
    {
        public static User MapToUser(this UserRequest userRequest)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Login = userRequest.Login,
                Password= userRequest.Password,
                Role=userRequest.Role,
                RefreshToken = userRequest.RefreshToken,
                IsBlocked = userRequest.IsBlocked,
            };
        }
    }
}
