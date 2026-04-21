using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.db.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "name field is required")]
        [MaxLength(50, ErrorMessage = "max length is 50 characters")]
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}