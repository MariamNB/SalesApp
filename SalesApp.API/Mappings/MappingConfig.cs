using AutoMapper;
using SalesApp.db.Entities;
using SalesApp.lib.DTOs;

namespace SalesApp.API.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
          
            CreateMap<CategoryDto, Category>().MaxDepth(10);
            CreateMap<ProductDto, Product>().MaxDepth(10);

            CreateMap<Category, GetCategoryDto>();
            CreateMap<Product, GetCategoryDto>();

      
        }
    }
}