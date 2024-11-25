using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Contract
{
    public class ValueAddContract
    {
        [Key]
        public Guid IdContratoAditivoValor { get; set; }

        [Column("valor_aditivo")]
        public decimal? ValorAditivo { get; set; }

        // Relacionamento com o contrato
        [ForeignKey("Contract")]
        public Guid ContractId { get; set; }

        public Contract Contract { get; set; }

        // Método para calcular o valor do aditivo
        public void CalcularValorContratoAditivoValor()
        {
            if (Contract.ContractValue.HasValue)
            {
                this.ValorAditivo = Contract.ContractValue.Value * 0.25m;
            }
        }
    }
}
