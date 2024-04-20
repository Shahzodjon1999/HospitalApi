using Hospital.Application.Authentication;
using Hospital.Application.Contract;
using Hospital.Application.InterfaceRepositoryes;
using Hospital.Application.Mapping;
using Hospital.Application.RequestModel;
using Hospital.Domen.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Hospital.Application.Services
{
    public class AuthService 
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserSessionToken> Login(string login,string password)
        {
            var user = _repository.GetAll().FirstOrDefault(k=>k.Login==login && k.Password==password);

            return await GeneratedJWt(user);
        }

        public async Task<UserSessionToken> RefreshToken(string refreshToken)
        {
            var user = _repository.GetAll().FirstOrDefault(k => k.RefreshToken==refreshToken);

            return await GeneratedJWt(user);

        }

        private async Task<UserSessionToken> GeneratedJWt(Auth user)
        {
            if (user is null)
                throw new ArgumentException("Invalid Login and Password");
            if (user is null) throw new ArgumentException("User doesn't have access to login");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Login),
                new Claim("Id",user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role.Name),
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
            return new UserSessionToken
            {
                AccessToken = accessToken,
                Role = user.Role.Name,
                RefreshToken = refreshToken
            };
        }
      
        public string Create(AuthRequest user)
        {
            if (string.IsNullOrEmpty(user.Login))
            {
                return "The name cannot be empty";
            }
            else
            {
                var mapuser = user.MapToUser();
                _repository.Create(mapuser);
                return $"Created new item with this ID: {mapuser.Id}";
            }
        }
    }
}
