using AutoMapper;
using Hospital.Application.Authentication;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Domen.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Hospital.Application.Services;

public class AuthService 
{
    private readonly IAuthRepository _repository;
    private readonly IMapper _mapper;
    public AuthService(IAuthRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AuthSessionToken> Login(string login,string password)
    {
        var user = _repository.GetAll().FirstOrDefault(k=>k.Login==login && k.Password==password);

        return await GeneratedJWt(user);
    }

    public async Task<AuthSessionToken> RefreshToken(string refreshToken)
    {
        var user = _repository.GetAll().FirstOrDefault(k => k.RefreshToken==refreshToken);

        return await GeneratedJWt(user);

    }

    private async Task<AuthSessionToken> GeneratedJWt(Auth user)
    {
        if (user is null)
            throw new ArgumentException("Invalid Login and Password");
        if (user is null) throw new ArgumentException("User doesn't have access to login");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.Login),
            new Claim("Id",user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Worker.Role.Name),
        };

        var jwt = new JwtSecurityToken(
            issuer:AuthOptions.Issuer,
            audience:AuthOptions.Audience,
            claims:claims,
            expires:DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.lifeTime)),
            signingCredentials:new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256));
   
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        var refreshToken = Guid.NewGuid().ToString();

        user.RefreshToken = refreshToken;
        _repository.Update(user);
        return new AuthSessionToken
        {
            AccessToken = accessToken,
            Role = user.Worker.Role.Name,
            RefreshToken = refreshToken
        };
    }
  
    public string Create(AuthRequest auth)
    {
        if (string.IsNullOrEmpty(auth.Login))
        {
            return "The name cannot be empty";
        }
        else
        {
            var mapuser = _mapper.Map<Auth>(auth);
            _repository.Create(mapuser);
            return $"Created new item with this ID: {mapuser.Id}";
        }
    }
}
