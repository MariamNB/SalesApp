using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Payments;
using Entities.Paymets;
using Microsoft.EntityFrameworkCore;
using SalesApp.db.Contexts;

namespace Repos.Payments
{
    public class PaymentMehtodRepo (AppDbContext context): IPaymentMethodsRepo
    {
        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
        {
            return await context.PaymentMethods.AsNoTracking().ToListAsync();
        }
    }
}