using lumos_asp.net_core_angular.Server.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace lumos_asp.net_core_angular.Server.Services.Auth
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        private readonly RsaSecurityKey _signingKey;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
            var privateKey = File.ReadAllText(_configuration["Jwt:PrivateKeyPath"]);
            var rsa = RSA.Create();
            rsa.ImportFromPem(privateKey.ToCharArray());
            _signingKey = new RsaSecurityKey(rsa);
        }

        public string GenerateAccessToken(User user, DateTime issuedAt, TimeSpan expiresIn)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, issuedAt.ToString()),
                new Claim("scope", string.Join(" ", user.UserRoles.Select(r => r.Role.RoleEnum)))
            };

            var credentials = new SigningCredentials(_signingKey, SecurityAlgorithms.RsaSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: issuedAt.Add(expiresIn),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken(User user, DateTime issuedAt, TimeSpan expiresIn)
        {
            // Similar to access token but without signing
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, issuedAt.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: issuedAt.Add(expiresIn)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
