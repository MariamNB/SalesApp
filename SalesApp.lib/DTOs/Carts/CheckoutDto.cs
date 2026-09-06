using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.DTOs.Carts
{
    public class CheckoutDto
    {
        public required Guid PaymentMethodId { get; set; }
        public required IEnumerable<CartDto> Carts { get; set; }
        
    }
}