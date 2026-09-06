using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.db.Base;
using SalesApp.db.Contexts;
using SalesApp.db.Entities;

namespace SalesApp.db.Repos
{
    public class CartRepo(AppDbContext context) : ICart
    {
        public async Task<int> SaveCheckoutHistory(IEnumerable<ProductHistory> checkouts)
        {
            context.ProductHistories.AddRange(checkouts);
            return await context.SaveChangesAsync();
        }
    }
}