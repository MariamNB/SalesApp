using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.DTOs
{
    public class ProductDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string?  Desciption { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public string? Image { get; set; }
        [Required]       
        public Guid? CategoryId { get; set; }

    }

    public class UpdateProductDto : ProductDto
    {
        public Guid Id { get; set; }
        
    }

    public class GetProductDto : ProductDto
    {
        public Guid Id { get; set; }

        public GetCategoryDto? Category {get; set;}
    }
}