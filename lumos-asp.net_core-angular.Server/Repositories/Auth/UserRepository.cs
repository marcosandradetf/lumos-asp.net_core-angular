using lumos_asp.net_core_angular.Server.Data;
using lumos_asp.net_core_angular.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> findByUsernameOrEmail(string usernameOrEmail)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u  => u.Username == usernameOrEmail);

            if (user == null)
                user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == usernameOrEmail);

            if (user == null)
                throw new Exception("User not found.");

            return user;

        }
    }
}
