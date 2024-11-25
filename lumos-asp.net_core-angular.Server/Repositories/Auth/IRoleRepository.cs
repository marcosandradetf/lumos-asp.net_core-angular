using lumos_asp.net_core_angular.Server.Models.Auth;
using static lumos_asp.net_core_angular.Server.Models.Auth.Role;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public interface IRoleRepository
    {
        Task<Role> FindByRoleAsync(Values roleEnum);
    }
}
