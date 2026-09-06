using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApp.db.Base.Products;
using SalesApp.db.Contexts;
using SalesApp.db.Entities;

namespace SalesApp.db.Repos.Products
{
    public class CategoryRepo(AppDbContext appDb) : ICategory
    {
        public async Task<IEnumerable<Product>> GetProductsWithCategory(Guid catId)
        {
            var proList = await appDb.Products.Include(x => x.Category)
                .Where(x => x.CategoryId == catId)
                .AsNoTracking().ToListAsync();

            return proList.Count > 0?proList : [];
        }
    }
}