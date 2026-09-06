using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.db.Entities;

namespace SalesApp.db.Base.Products
{
    public interface ICategory
    {
        Task<IEnumerable<Product>> GetProductsWithCategory(Guid catId);
        
    }
}