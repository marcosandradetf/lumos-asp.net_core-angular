using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace lumos_asp.net_core_angular.Server.Models.Stock
{
    public class Company
    {
        [Key]
        public Guid IdCompany { get; set; }

        [MaxLength(100)]
        public string CompanyName { get; set; }

    }
}
