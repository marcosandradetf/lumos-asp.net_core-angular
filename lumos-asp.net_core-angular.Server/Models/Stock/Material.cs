using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class Material
    {
        [Key]
        public Guid IdMaterial { get; set; }
        [MaxLength(100)]
        public string MaterialName { get; set; }

        [Column(TypeName = "TEXT")]
        public string MaterialBrand { get; set; }

        public float? MaterialPower { get; set; }

        [Column(TypeName = "TEXT")]
        public string BuyUnit { get; set; }

        [Column(TypeName = "TEXT")]
        public string RequestUnit { get; set; }

        [ForeignKey("MaterialType")]
        public Guid MaterialTypeId { get; set; }

        public Type MaterialType { get; set; }

        public List<Contract.Contract> Contracts { get; set; } = [];

        [Required]
        [DefaultValue(0)]
        public int StockQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        public int StockAvailable { get; set; }

        public decimal? CostPrice { get; set; }

        [Required]
        [DefaultValue("false")]
        public bool Inactive { get; set; }


        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }


        [ForeignKey("Deposit")]
        public Guid? DepositId { get; set; }
        public Deposit Deposit { get; set; }

        public void AddStockQuantity(int quantityCompleted)
        {
            this.StockQuantity += quantityCompleted;
        }

        public void AddStockAvailable(int quantityAvailable)
        {
            this.StockAvailable += quantityAvailable;
        }

        public void RemoveStockQuantity(int quantityCompleted)
        {
            this.StockQuantity -= quantityCompleted;
        }

        public void RemoveStockAvailable(int quantityAvailable)
        {
            this.StockAvailable -= quantityAvailable;
        }
    }
}
