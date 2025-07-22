using CampusConnectAPI.DTOs.Auth;
using CampusConnectAPI.Models;

namespace CampusConnectAPI.Services.Interfaces
{
    public interface IAuthSevices
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        Task<User> GetUserProfilesAsync(string email);
    }
}
