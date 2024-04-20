using Hospital.Domen.Abstract;
using System.Text.Json.Serialization;

namespace Hospital.Domen.Model;

public class Auth: EntityBase
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public bool IsBlocked { get; set; }

    [JsonIgnore]
    public Role? Role { get; set; }
    public Guid RoleId { get; set; }

    [JsonIgnore]
    public Worker? Worker { get; set; }

    public Guid WorkerId { get; set; }
}
