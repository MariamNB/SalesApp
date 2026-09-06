using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.API.Base;
using SalesApp.db.Entities;
using SalesApp.lib.DTOs;
using SalesApp.lib.DTOs.Carts;
using Stripe.Checkout;

namespace Services.Payments
{
    public class PaymentService : IPaymentService
    {
        public async Task<ResponseDto> PayMoney(decimal totalAmount, IEnumerable<Product> products, IEnumerable<CartDto> carts)
        {
            try
            {
                var lines = new List<SessionLineItemOptions>();
                foreach (var product in products)
                {
                    var productQty = carts.FirstOrDefault(c => c.ProductId == product.Id);
                    if (productQty != null)
                    {
                        lines.Add(new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmountDecimal = product.Price * 100, // Convert to cents
                                Currency = "usd",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = product.Name,
                                    Description = product.Desciption
                                }
                            },
                            Quantity = productQty.Quantity
                        });
                    }
                }
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = ["usd"],
                    LineItems = lines,
                    Mode = "payment",
                    SuccessUrl = "http://localhost:5080/paymentSuccess",
                    CancelUrl = "http://localhost:5080/paymentCancel"
                };

                var service = new SessionService();
                Session session = await service.CreateAsync(options);

                return new ResponseDto (true, session.Url );
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, $"Payment processing failed: {ex.Message}");
            }
        }
    }
}