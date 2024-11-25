using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lumos_asp.net_core_angular.Server.Models.Contract
{
    public class TeamContract
    {
        [Key]
        public Guid TeamId { get; set; }
    }
}
