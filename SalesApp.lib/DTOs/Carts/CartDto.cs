using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.DTOs.Carts
{
    public class CartDto
    {
        public required Guid ProductId { get; set; } 
        public required int Quantity { get; set; }
    }
}