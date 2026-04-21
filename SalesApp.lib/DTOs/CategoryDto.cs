using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string? Name { get; set; }
    }

    public class UpdateCategoryDTO : CategoryDto
    {
        public Guid Id { get; set; }
        
    }

    public class GetCategoryDto : CategoryDto
    {
        public Guid Id { get; set; }

        public ICollection<GetProductDto>? Products {get; set;}
        
    }
}