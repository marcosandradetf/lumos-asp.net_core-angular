using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using BCrypt.Net;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Auth
{
    [Table("tb_users")]
    public class User
    {

        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public List<UserRole> UserRoles { get; } = [];
        public ICollection<RefreshToken> RefreshTokens { get; } = new List<RefreshToken>();

        public bool IsLoginCorrect(string providedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, this.Password);
        }
    }
}