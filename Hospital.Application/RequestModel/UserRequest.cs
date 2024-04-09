using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class UserRequest : EntityBaseRequest
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public bool IsBlocked { get; set; }
}
