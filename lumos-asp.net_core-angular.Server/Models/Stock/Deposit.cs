using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class Deposit
    {
        [Key]
        public Guid IdDeposit { get; set; }

        [Column(TypeName = "TEXT")]
        public string DepositName { get; set; }
    }
}
