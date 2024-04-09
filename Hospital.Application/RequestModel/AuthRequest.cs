using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public class AuthRequest : EntityBaseRequest
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}
