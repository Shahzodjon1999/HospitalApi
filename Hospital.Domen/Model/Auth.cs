using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Auth: EntityBase
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public bool IsBlocked { get; set; }

    public Worker? Worker { get; set; }
    public Guid WorkerId { get; set; }
}
