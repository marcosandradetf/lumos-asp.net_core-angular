using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Execution
{
    public class PreMeasurement
    {
        [Key]
        public Guid IdMeasurement { get; set; }

        [Column(TypeName = "TEXT")]
        public string City { get; set; }

        public List<Team> Teams { get; set; } = [];

    }
}
