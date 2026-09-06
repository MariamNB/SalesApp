using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesApp.lib.DTOs.Carts
{
    public class ProductHistryDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid UserId { get; set; }

    }
}