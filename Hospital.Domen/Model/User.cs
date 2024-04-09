using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class User:Person
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;

    public string Role { get; set; }=string.Empty;

    public bool IsBlocked { get; set; }
}
