using AutoMapper;
using DTOs.Identity;
using DTOs.Payments;
using Entities.Identity;
using Entities.Paymets;
using SalesApp.db.Entities;
using SalesApp.lib.DTOs;
using SalesApp.lib.DTOs.Carts;

namespace SalesApp.API.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
          
            CreateMap<CategoryDto, Category>().MaxDepth(10);
            CreateMap<ProductDto, Product>().MaxDepth(10);

            CreateMap<Category, GetCategoryDto>();
            CreateMap<Product, GetProductDto>();

            CreateMap<CreateUser, AppUser>();
            CreateMap<LogInUser, AppUser>();

            CreateMap<PaymentMehodDto, PaymentMethod>();

            CreateMap<ProductHistory, ProductHistryDto>();
        }
    }
}