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
using SalesApp.lib.Base;
using SalesApp.lib.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Entities.Identity;
using Base.Authentication;
using Repos.Authentication;
using Base.Payments;
using Repos.Payments;
using SalesApp.db.Base.Products;
using SalesApp.db.Repos.Products;


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
            services.AddScoped(typeof(IAppLoger<>), typeof(SerlilogAppAdapter<>));
            
            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;   
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(options=>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = conf["JWT:Issuer"],
                    ValidAudience = conf["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(conf["JWT:Key"]!))
                };
            });

            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<ITokenManagement, TokenManagement>();
            services.AddScoped<IRoleManagement, RoleManagement>();

            services.AddScoped<IPaymentMethodsRepo, PaymentMehtodRepo>();

            services.AddScoped<ICategory, CategoryRepo>();

            return services;
        }
        public static IApplicationBuilder AddMiddleWareDb(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExHandlingMiddleware>();
            return app;
            
        }
    }
}