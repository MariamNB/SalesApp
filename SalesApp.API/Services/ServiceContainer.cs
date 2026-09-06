using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.API.Base;
using SalesApp.API.Mappings;
using SalesApp.db.Entities;
using SalesApp.lib.Base;
using SalesApp.lib.Services;
using Services.Authentication;
using Services.Payments;
using Validations.Identity;

namespace SalesApp.API.Services
{
    public  static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionsApi(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            //services.AddValidatorsFromAssemblyContaining<LogInUserValidator>();

            services.AddScoped<IValidationServices, ValidationServices>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            
            services.AddScoped<IPaymentService, PaymentService>();
            
            return services;
        }
    }
}