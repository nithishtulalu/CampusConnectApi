using CampusConnectAPI.Models;

namespace CampusConnectAPI.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> RegisterAsync(User user , string password);
        Task<User> LoginAsync(string email, string password);
        Task<User> GetUserByEmailAsync(string email);
    }
}
