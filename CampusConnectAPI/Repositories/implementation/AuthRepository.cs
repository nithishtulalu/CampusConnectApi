using CampusConnectAPI.Models;
using CampusConnectAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampusConnectAPI.Repositories.implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<User> RegisterAsync(User user, string password)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<User> LoginAsync(string email, string password)
        {
            try
            {
                var user = await _context.Users.Include(u=>u.Role).FirstOrDefaultAsync(u => u.Email == email);

                if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                    return null;
                return user;
            }
            catch (Exception ex) { return null; }

        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try {
                return await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == email);
            }
            catch(Exception ex) { return null; }
           
        }
    }
}
