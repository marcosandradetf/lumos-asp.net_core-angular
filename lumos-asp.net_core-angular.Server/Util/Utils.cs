using lumos_asp.net_core_angular.Server.Models.Auth;
using lumos_asp.net_core_angular.Server.Repositories.Auth;

namespace lumos_asp.net_core_angular.Server.Util
{
    public class Utils(IRefreshTokenRepository refreshTokenRepository)
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

        // Método para converter uma string para BigDecimal (em C# será Decimal)
        public static decimal? ConvertToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            try
            {
                var newValue = value.Replace(",", ".");
                return decimal.Parse(newValue);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Método para obter o usuário a partir de um refresh token
        public async Task<User?> GetUserFromRToken(string rToken)
        {
            var tokenFromDb = await _refreshTokenRepository.FindByTokenAsync(rToken);
            if (tokenFromDb == null)
            {
                return null;
            }

            return tokenFromDb.User;
        }

        // Método para verificar se uma string está vazia ou é nula
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public enum Status
        {
            PENDING = 1,
            APPROVED = 2,
            REJECTED = 3,
        }

    }
}

