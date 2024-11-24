using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using lumos_asp.net_core_angular.Server.Models.Auth;
using lumos_asp.net_core_angular.Server.Repositories.Auth;
using lumos_asp.net_core_angular.Server.DTOs.Auth;
using lumos_asp.net_core_angular.Server.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace lumos_asp.net_core_angular.Server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class TokenController(
        JwtService jwtService,
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IConfiguration config) : ControllerBase
    {
        private readonly JwtService _jwtService = jwtService;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
        private IConfiguration _config = config;

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new { message = "API funcionando!" });
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var user = await _userRepository.findByUsernameOrEmail(loginRequest.usernameOrEmail);
            if (user == null || !user.IsLoginCorrect(loginRequest.password))
            {
                return Unauthorized("Usuário/email ou senha incorretos");
            }

            var now = DateTime.UtcNow;
            var accessTokenExpiresIn = TimeSpan.FromMinutes(5);
            var refreshTokenExpiresIn = TimeSpan.FromDays(1);

            var accessToken = _jwtService.GenerateAccessToken(user, now, accessTokenExpiresIn);
            var refreshToken = _jwtService.GenerateRefreshToken(user, now, refreshTokenExpiresIn);

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = now.Add(refreshTokenExpiresIn),
                User = user,
                UserId = user.UserId,
                Revoked = false
            };

            await _refreshTokenRepository.AddAsync(refreshTokenEntity);

            // Set refresh token as HTTP-Only cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,  // Only in HTTPS environments
                SameSite = SameSiteMode.Strict,
                Expires = now.Add(refreshTokenExpiresIn)
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);

            return Ok(new LoginResponse
            {
                AccessToken = accessToken,
                ExpiresIn = (long)accessTokenExpiresIn.TotalSeconds,
                Roles = string.Join(" ", user.UserRoles.Select(r => r.Role.RoleEnum))
            });
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromHeader(Name = "Cookie")] string cookies)
        {
            // Extraindo o refreshToken dos cookies
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("No refresh token found");
            }

            // Localiza o token no banco de dados
            var tokenFromDb = await _refreshTokenRepository.FindByTokenAsync(refreshToken);
            if (tokenFromDb != null)
            {
                tokenFromDb.Revoked = true;
                await _refreshTokenRepository.UpdateAsync(tokenFromDb);
            }

            // Remove o cookie do refresh token
            Response.Cookies.Append("refreshToken", "", new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Apenas para HTTPS em produção
                Expires = DateTimeOffset.UtcNow.AddDays(-1), // Define uma expiração passada para deletar o cookie
                Path = "/"
            });

            return NoContent();
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromHeader(Name = "Cookie")] string cookies)
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var now = DateTime.UtcNow;
            var expiresIn = TimeSpan.FromMinutes(5);

            var tokenFromDb = await _refreshTokenRepository.FindByTokenAsync(refreshToken);
            if (!tokenFromDb.Revoked || tokenFromDb == null || tokenFromDb.ExpiryDate > now)
            {
                return Unauthorized();
            }

            var user = tokenFromDb.User;
            var newAccessTooken = _jwtService.GenerateAccessToken(user, now, expiresIn);

            return Ok(new LoginResponse
            {
                AccessToken = newAccessTooken,
                ExpiresIn = (long)expiresIn.TotalSeconds,
                Roles = string.Join(" ", user.UserRoles.Select(r => r.Role.RoleEnum))
            });
        }


    }
}
