using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lumos_asp.net_core_angular.Server.Models.Auth
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        public Values RoleEnum { get; set; }
        public ICollection<User> Users { get; set; } = [];
        public enum Values
        {
            ADMIN = 1,
            MANAGER = 2,
            BASIC = 3
        }
    }
}