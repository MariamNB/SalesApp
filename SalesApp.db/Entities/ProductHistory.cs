using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.db.Entities
{
    public class ProductHistory
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //  public string? ProductName { get; set; }
        // public decimal ProductPrice { get; set; }
        // public decimal TotalAmount { get; set; }
    }
}