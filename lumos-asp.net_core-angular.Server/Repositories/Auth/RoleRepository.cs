using lumos_asp.net_core_angular.Server.Data;
using lumos_asp.net_core_angular.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;
using static lumos_asp.net_core_angular.Server.Models.Auth.Role;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public class RoleRepository(ApplicationDbContext context) : IRoleRepository
    {
        public async Task<Role> FindByRoleAsync(Values roleEnum)
        {
            // Busca o primeiro papel que corresponde ao roleEnum
            var role = await context.Roles
                .FirstOrDefaultAsync(r => r.RoleEnum == roleEnum);


            // Se não encontrar, lança uma exceção
            if (role == null)
            {
                throw new Exception("Role not found.");
            }

            return role;
        }
    }
}
