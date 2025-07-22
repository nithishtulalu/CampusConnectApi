using System.Security.Claims;
using CampusConnectAPI.DTOs.Auth;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthSevices _authSevices;

        public AuthController( IAuthSevices authSevices)
        {
            _authSevices = authSevices;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result= await _authSevices.RegisterAsync(registerDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var  result= await _authSevices.LoginAsync(loginDto);
            if(result == null) 
                return Unauthorized("invalid credentials");
            return Ok(result);
        }

        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var email= User.FindFirstValue(ClaimTypes.Email);
            var user=  await _authSevices.GetUserProfilesAsync(email);
            return Ok(new
            {
                user.UserId,
                user.FullName,
                user.Email,
                Role=user.Role?.RoleName??"unknown"
            });

        }
    }
}
