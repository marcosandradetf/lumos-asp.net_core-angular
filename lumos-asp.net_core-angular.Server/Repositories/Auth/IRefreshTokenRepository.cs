using lumos_asp.net_core_angular.Server.Models.Auth;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> FindByTokenAsync(string token);
        Task DeleteByUserAsync(Guid userId);
        Task AddAsync(RefreshToken refreshTokenEntity);
        Task UpdateAsync(RefreshToken tokenFromDb);
    }
}
