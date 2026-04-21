using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.db.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "name field is required")]
        [MaxLength(50, ErrorMessage = "max length is 50 characters")]
        public string? Name { get; set; }

        [MaxLength(100, ErrorMessage = "max length is 100 characters")]
        public string?  Desciption { get; set; }
        [Column(TypeName = "decimal(16,4)")]
        public decimal? Price { get; set; }
        public string? Image { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public Guid? CategoryId { get; set; }

    }
}