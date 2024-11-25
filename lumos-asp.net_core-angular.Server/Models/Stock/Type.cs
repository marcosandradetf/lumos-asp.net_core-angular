using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class Type
    {
        [Key]
        public Guid IdType { get; set; }

        [Column(TypeName = "TEXT")]
        public string TypeName { get; set; }

        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        public Group Group { get; set; }

    }
}
