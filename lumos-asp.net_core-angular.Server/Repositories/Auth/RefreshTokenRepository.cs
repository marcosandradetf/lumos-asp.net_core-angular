using lumos_asp.net_core_angular.Server.Data;
using lumos_asp.net_core_angular.Server.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace lumos_asp.net_core_angular.Server.Repositories.Auth
{
    public class RefreshTokenRepository(ApplicationDbContext context) : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task DeleteByUserAsync(Guid userId)
        {
            var user = await _context.RefreshTokens
                .FirstOrDefaultAsync(u => u.UserId == userId); // Encontrando token pelo usuario

            if (user != null)
            {
                _context.RefreshTokens.Remove(user);  // Remover o token
                await _context.SaveChangesAsync(); // Persistir a alteração no banco
            }
        }


        public async Task<RefreshToken> FindByTokenAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(u => u.Token == token);

            return refreshToken ?? throw new Exception("Refresh token not found.");
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            await _context.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        async Task<RefreshToken> IRefreshTokenRepository.FindByTokenAsync(string token)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(r => r.Token == token);
            
            if (refreshToken == null)
                throw new NotImplementedException();

            return refreshToken;
        }

        Task IRefreshTokenRepository.DeleteByUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        async Task IRefreshTokenRepository.AddAsync(RefreshToken refreshTokenEntity)
        {
            _context.RefreshTokens.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RefreshToken tokenFromDb)
        {
            _context.RefreshTokens.Update(tokenFromDb);
            await _context.SaveChangesAsync();
        }

    }
}
