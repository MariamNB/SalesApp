
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SalesApp.db.Entities;

namespace SalesApp.db.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
       
    }
}