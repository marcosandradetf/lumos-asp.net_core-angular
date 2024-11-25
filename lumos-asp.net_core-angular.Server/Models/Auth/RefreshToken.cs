using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lumos_asp.net_core_angular.Server.Models.Auth
{
    public class RefreshToken
    {
        [Key]
        public Guid TokenId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Revoked { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
