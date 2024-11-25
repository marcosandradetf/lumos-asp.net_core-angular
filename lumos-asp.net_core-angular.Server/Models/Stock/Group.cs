using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class Group
    {
        [Key]
        public Guid IdGroup { get; set; }

        [Column(TypeName = "TEXT")]
        public string GroupName { get; set; }
    }
}
