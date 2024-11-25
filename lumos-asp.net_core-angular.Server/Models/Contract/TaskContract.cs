using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Contract
{
    public class TaskContract
    {
        [Key]
        public Guid IdTarefa { get; set; }

        [ForeignKey("Contract")]
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }

        [ForeignKey(nameof(TeamContract))]
        public Guid TeamId { get; set; }
        public TeamContract Team { get; set; }
        public int QuantidadeRecebida { get; set; }
        public int QuantidadeExecutada { get; set; }
    }
}
