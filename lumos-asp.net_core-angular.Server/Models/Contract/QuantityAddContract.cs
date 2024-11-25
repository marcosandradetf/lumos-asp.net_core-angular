using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Contract
{
    public class QuantityAddContract
    {
        [Key]
        public Guid IdContratoAditivoQuantitativo { get; set; }

        public decimal? ValorAditivoQuantitativo { get; set; }

        // Relacionamento com o contrato
        [ForeignKey("Contract")]
        public Guid ContractId { get; set; }

        public Contract Contract { get; set; }

        // Método para calcular o valor do aditivo quantitativo
        public void CalcularValorContratoAditivoQuantitativo()
        {
            if (Contract.ContractValue.HasValue)
            {
                this.ValorAditivoQuantitativo = Contract.ContractValue.Value * 0.25m;
            }
        }

    }
}
