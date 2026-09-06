using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Base.Payments;
using DTOs.Payments;
using SalesApp.lib.Base;

namespace Services.Payments
{
    public class PaymentMethodService(IPaymentMethodsRepo repo, IMapper mapper) : IPaymentMethodService
    {
        public async Task<IEnumerable<PaymentMehodDto>> GetPaymentMehod()
        {
            var methods = await repo.GetAllPaymentMethods();
            if(!methods.Any())
            {
                return [];
                // throw new Exception("No payment methods found");
            }
            return mapper.Map<IEnumerable<PaymentMehodDto>>(methods);
        }
    }
}