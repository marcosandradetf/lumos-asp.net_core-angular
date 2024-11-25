using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using lumos_asp.net_core_angular.Server.Models.Stock;
using lumos_asp.net_core_angular.Server.Util;

namespace lumos_asp.net_core_angular.Server.Models.Execution
{
    public class MaterialReservation
    {
        [Key]
        public Guid IdMaterialReservation { get; set; }

        [Column(TypeName = "TEXT")]
        public string StockReservationName { get; set; }

        [ForeignKey("Material")]
        public Guid MaterialId { get; set; }

        [ForeignKey("PreMeasurement")]
        public Guid PreMeasurementId { get; set; }

        public Material Material { get; set; }
        public PreMeasurement PreMeasurement { get; set; }

        [Required]
        public int ReservedQuantity { get; set; }

        [Required]
        public int QuantityCompleted { get; set; }

        public Utils.Status Status { get; set; } // Pode ser "pendente", "coletado", "cancelado

        public void SetReservedQuantity(int reservedQuantity)
        {
            ReservedQuantity = reservedQuantity;
            // Atualizando a quantidade disponível do material
            Material?.RemoveStockAvailable(reservedQuantity);
        }

        public void SetQuantityCompleted(int quantityCompleted)
        {
            QuantityCompleted = quantityCompleted;
            // Atualizando a quantidade do material
            Material?.RemoveStockQuantity(quantityCompleted);
        }

    }
}
