using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Payments;

namespace SalesApp.lib.Base
{
    public interface IPaymentMethodService
    {
        Task <IEnumerable<PaymentMehodDto>> GetPaymentMehod();
    }
}