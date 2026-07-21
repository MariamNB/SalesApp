using Microsoft.EntityFrameworkCore;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesApp.db.Base;
using SalesApp.db.Contexts;
using SalesApp.db.Entities;
using SalesApp.db.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.lib.Exceptions;
using Microsoft.AspNetCore.Builder;

namespace SalesApp.db.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInjectionOptionsDb(this IServiceCollection services, IConfiguration conf)
        {
            string conStr = "ConStr";
            string? con = conf.GetConnectionString(conStr);
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(con,
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure();
                }).UseExceptionProcessor(),
                ServiceLifetime.Scoped
                );
            services.AddScoped<IGeneralRepo<Category>, GeneralReop<Category>>();
            services.AddScoped<IGeneralRepo<Product>, GeneralReop<Product>>();
            return services;
        }
        public static IApplicationBuilder AddMiddleWareDb(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExHandlingMiddleware>();
            return app;
            
        }
    }
}