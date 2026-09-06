using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.db.Entities;

namespace SalesApp.db.Base
{
    public interface ICart
    {
        Task<int> SaveCheckoutHistory(IEnumerable<ProductHistory> checkouts);
    }
}