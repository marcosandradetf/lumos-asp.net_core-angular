using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class Supplier
    {
        [Key]
        public Guid SupplierId { get; set; }

        [Column(TypeName = "TEXT")]
        public string SupplierName { get; set; }

        [Column(TypeName = "TEXT")]
        public string SupplierCnpj { get; set; }

        [Column(TypeName = "TEXT")]
        public string SupplierContact { get; set; }

        [Column(TypeName = "TEXT")]
        public string SupplierAddress { get; set; }

        [Column(TypeName = "TEXT")]
        public string SupplierPhone { get; set; }

        [Column(TypeName = "TEXT")]
        public string SupplierEmail { get; set; }

    }
}
