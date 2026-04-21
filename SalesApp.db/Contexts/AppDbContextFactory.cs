using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SalesApp.db.Contexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

           optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=SalesDb;User Id=sa;Password=Pass@Xyz983;TrustServerCertificate=True;",
            sql =>
            {
                sql.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                sql.EnableRetryOnFailure();
             });

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}