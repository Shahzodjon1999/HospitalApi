using Hospital.Domen.Abstract;

namespace Hospital.Domen.Model;

public class Client :Person
{
    public string Login { get; set; }=string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email {  get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
