using Hospital.Application.RequestModel;
using Hospital.Application.ResponseModel;
using Hospital.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace Hospital.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] AuthGetTokenRequest request)
        {
            try
            {
                AuthSessionToken token = await _authService.Login(request.Username,request.Password);
               
                return Ok(token);
            }
            catch (Exception ex)
            {
                Log.Information($"This is Auth Conntroller Error: {ex.Message}");
                return Unauthorized();
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            try
            {
                AuthSessionToken token = await _authService.RefreshToken(refreshToken);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] AuthRequest userRequest)
        {
            try
            {
                Log.Information("In the method Create request=>{@request}", userRequest);
                return _authService.Create(userRequest);
            }
            catch (SqlException es)
            {
                return $"Didn't find Id {es.Message}";
            }
            catch (Exception ex)
            {
                Log.Error("You have Error In the method Create()=>{@ex}", ex.Message);
                throw new Exception($"You have exception:{ex.Message} in the Method Create");
            }
        }
         
    }
}
