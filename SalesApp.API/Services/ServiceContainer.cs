using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.API.Base;
using SalesApp.API.Mappings;
using SalesApp.db.Entities;
using SalesApp.lib.Base;
using SalesApp.lib.Services;

namespace SalesApp.API.Services
{
    public  static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionsApi(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}