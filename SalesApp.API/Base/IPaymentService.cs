using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.db.Entities;
using SalesApp.lib.DTOs;
using SalesApp.lib.DTOs.Carts;

namespace SalesApp.API.Base
{
    public interface IPaymentService
    {
        Task<ResponseDto> PayMoney(decimal totalAmount, IEnumerable<Product> products,IEnumerable<CartDto> carts);
    }
}