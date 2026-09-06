using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Paymets;

namespace Base.Payments
{
    public interface IPaymentMethodsRepo
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();
    }
}