using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Execution
{
    public class Street
    {
        [Key]
        public Guid IdStreet { get; set; }

        [Column(TypeName = "TEXT")]
        public string Name { get; set; }
        public List<Item> Items { get; set; } = [];

    }
}
