using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using lumos_asp.net_core_angular.Server.Models.Stock;
using Microsoft.EntityFrameworkCore;

namespace lumos_asp.net_core_angular.Server.Models.Execution
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdItem { get; set; }

        public int ItemQuantity { get; set; }

        [Precision(18, 2)]
        public decimal ItemValue { get; set; } = 0m;

        [Precision(18, 2)]
        public decimal ItemTotalValue { get; set; } = 0m;

        [ForeignKey("Material")]
        public Guid MaterialId { get; set; }
        [ForeignKey("Contract")]
        public Guid ContractId { get; set; }
        public Material Material { get; set; }
        public Contract.Contract Contract { get; set; }
        public List<Street> Streets { get; set; } = [];

        // Método para calcular o valor total do contrato
        private void CalculateContractTotalValue()
        {
            ItemTotalValue = ItemValue * ItemQuantity;

            // Verifica se o valor do contrato não é nulo e, se for, define-o como zero antes de somar
            if (Contract.ContractValue == null)
            {
                Contract.ContractValue = 0m;
            }

            // Adiciona o valor total do item ao valor total do contrato
            Contract.ContractValue += this.ItemTotalValue;
        }

        private void RemoveStockAvailable()
        {
            int stockAvailable = Material.StockAvailable;
            if (stockAvailable > 0)
            {
                Material.RemoveStockAvailable(ItemQuantity);
            }
        }

    }
}
