
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SalesApp.db.Entities;
using Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Entities.Paymets;

namespace SalesApp.db.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}

        public DbSet<RefreshToken> RefreshTokens {get; set;}

        public DbSet<PaymentMethod> PaymentMethods {get; set;}

        public DbSet<ProductHistory> ProductHistories {get; set;}
       
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Id = "049b5bc4-fe65-4d3b-9f4f-cdf53f159342", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "c90f1608-5b70-4635-ac62-84bdcda998de", Name = "User", NormalizedName = "USER" }
                );

             modelBuilder.Entity<PaymentMethod>()
                .HasData(
                    new PaymentMethod { Id = Guid.Parse("f3036914-100d-4a0e-816a-8d16b5825f46"), Name = "Cash"},
                    new PaymentMethod { Id = Guid.Parse("834b1a27-1409-4d34-9746-370325b39d79"), Name = "Visa Card"}
                );
        }
    }
}