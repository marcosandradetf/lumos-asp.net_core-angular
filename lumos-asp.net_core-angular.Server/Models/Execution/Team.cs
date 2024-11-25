using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Execution
{
    public class Team
    {
        [Key]
        public Guid IdTeam { get; set; }
        public string TeamName { get; set; }
        public string Region { get; set; }
        public List<PreMeasurement> PreMeasurements { get; set; } = [];

    }
}
