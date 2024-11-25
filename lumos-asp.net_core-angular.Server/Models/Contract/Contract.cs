using lumos_asp.net_core_angular.Server.Models.Execution;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Contract
{
    public class Contract
    {
        [Key]
        public Guid IdContract { get; set; }

        [Column("contract_number")]
        public string ContractNumber { get; set; }

        [Column("contract_doc")]
        public string ContractDoc { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("contract_value")]
        public decimal? ContractValue { get; set; }

        public string City { get; set; }

        public string Uf { get; set; }

        // Relacionamento com Itens do Contrato
        [InverseProperty("Contract")]
        public List<Item> ItemsContract { get; set; } = [];

        // Método para adicionar um item ao contrato
        public void AddItemContrato(Item item)
        {
            ItemsContract.Add(item);
            item.Contract = this;
        }
    }
}
