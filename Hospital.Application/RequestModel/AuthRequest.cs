using Hospital.Application.Entity;
using Hospital.Domen.Model;
using System.Text.Json.Serialization;

namespace Hospital.Application.RequestModel;

public record AuthRequest : EntityBaseRequest
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public bool IsBlocked { get; set; }
    [JsonIgnore]
    public Role? Role { get; set; }
    public Guid RoleId { get; set; }
    [JsonIgnore]
    public Worker? Worker { get; set; }
    public Guid WorkerId { get; set; }
}
