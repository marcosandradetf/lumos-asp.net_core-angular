using lumos_asp.net_core_angular.Server.Data;
using lumos_asp.net_core_angular.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        public async Task<Role> findByRoleNameAsync(int roleEnum)
        {
            var role = await context.Roles
                .FirstOrDefaultAsync(r => r.RoleEnum == roleEnum);
            return role ?? throw new Exception("Role not found.");
        }
    }
}
