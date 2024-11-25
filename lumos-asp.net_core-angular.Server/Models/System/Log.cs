using lumos_asp.net_core_angular.Server.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.System
{
    public class Log
    {
        [Key]
        public Guid IdLog { get; set; }

        [Column(TypeName = "TEXT")]
        public string Message { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationTimestamp { get; set; }

        [Column(TypeName = "TEXT")]
        public string Type { get; set; }

        [Column(TypeName = "TEXT")]
        public string Category { get; set; }

        public User User { get; set; }

    }
}
