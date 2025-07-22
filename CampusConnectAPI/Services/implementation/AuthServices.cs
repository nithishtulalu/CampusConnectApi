using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CampusConnectAPI.DTOs.Auth;
using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using CampusConnectAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;


namespace CampusConnectAPI.Services.implementation
{
    public class AuthServices : IAuthSevices
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;


        public AuthServices(IAuthRepository repo, IConfiguration config , IHttpContextAccessor httpContextAccessor , ApplicationDbContext context)
        {
            _authRepository = repo;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var user = new User
                {
                    FullName = registerDto.FullName,
                    Email = registerDto.Email,
                    RoleId = registerDto.RoleId,
                };
                var createdUser = await _authRepository.RegisterAsync(user, registerDto.Password);
                var fullUser = await _authRepository.GetUserByEmailAsync(createdUser.Email);
                var token = GenerateJwtToken(fullUser);
                return new AuthResponseDto { 
                    Email = fullUser.Email,
                    FullName= fullUser.FullName,
                    Token = token,
                };


            }
            catch (Exception ex)
            {
                return null;
            }

        }


        private string GenerateJwtToken(User user)
        {
            try
            {
                var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role , user.Role?.RoleName?? "User")
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("JWT generation failed: " + ex.Message);
                return null;
            }

        }

        public async  Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _authRepository.LoginAsync(loginDto.Email, loginDto.Password);
                if (user == null)
                    return null;

                // save login  entry 
                var ipAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknow";
                var loginlog = new UserLogin
                {
                    LoginId = Guid.NewGuid(),
                    UserId = user.UserId,
                    LoginTime = DateTime.UtcNow,
                    IpAddress = ipAddress
                };
                _context.UsersLogin.Add(loginlog);
                await _context.SaveChangesAsync();

                var token = GenerateJwtToken(user);
                return new AuthResponseDto
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    Token = token
                };




            }
            catch (Exception ex)
            {
                return null;
            }

        }

      

        public async Task<User> GetUserProfilesAsync(string email)
        {
            try
            {
                return await _authRepository.GetUserByEmailAsync(email);
            }
            catch (Exception ex) { 
                return null;
            }
        }


    }
}
