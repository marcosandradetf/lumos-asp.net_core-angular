using lumos_asp.net_core_angular.Server.Models.Auth;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<User> FindByUsernameOrEmailAsync(string usernameOrEmail);
        Task AddAsync(User user);
    }
}
