namespace Hospital.Application.Contract;

public record UserSessionToken
{
    public string AccessToken { get; set;}=string.Empty;

    public string Role {  get; set;}=string.Empty;

    public string RefreshToken { get; set;}=string.Empty;
}
