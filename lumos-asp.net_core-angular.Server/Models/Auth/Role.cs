using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lumos_asp.net_core_angular.Server.Models.Auth
{
    [Table("tb_roles")]
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        public int RoleEnum { get; set; }
        public List<UserRole> UserRoles { get; } = [];
        public enum Values
        {
            ADMIN = 1,
            MANAGER = 2,
            BASIC = 3
        }
    }
}