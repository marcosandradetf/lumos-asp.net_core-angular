using lumos_asp.net_core_angular.Server.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using lumos_asp.net_core_angular.Server.Util;

namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class StockMovement(DateTime stockMovementRefresh)
    {
        [Key]
        public Guid StockMovementId { get; set; }

        [Column(TypeName = "TEXT")]
        public string StockMovementDescription { get; set; }

        [ForeignKey("Material")]
        public Guid? MaterialId { get; set; }

        public Material Material { get; set; }

        [Required]
        public DateTime StockMovementRefresh { get; set; } = stockMovementRefresh;

        [ForeignKey("UserCreated")]
        public Guid? UserCreatedId { get; set; }

        public User UserCreated { get; set; }

        [ForeignKey("UserFinished")]
        public Guid? UserFinishedId { get; set; }

        public User UserFinished { get; set; }

        [Required]
        [DefaultValue(0)]
        public int InputQuantity { get; set; }

        [Column(TypeName = "TEXT")]
        public string BuyUnit { get; set; }

        [Required]
        [DefaultValue(0)]
        public int QuantityPackage { get; set; }

        public decimal? PricePerItem { get; set; }

        [ForeignKey("Supplier")]
        public Guid? SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [Column(TypeName = "TEXT")]
        public Utils.Status Status { get; set; }


        // Método para atualizar o estoque do material
        public void MaterialUpdate()
        {
            int stockQuantity = InputQuantity * QuantityPackage;
            Material.AddStockQuantity(stockQuantity);
            Material.AddStockAvailable(stockQuantity);
            Material.CostPrice = PricePerItem;
        }
    }
}
