using Hospital.Application.Entity;

namespace Hospital.Application.RequestModel;

public record AuthGetTokenRequest : EntityBaseRequest
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}
