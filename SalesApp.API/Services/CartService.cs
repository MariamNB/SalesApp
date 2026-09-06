using AutoMapper;
using SalesApp.API.Base;
using SalesApp.db.Base;
using SalesApp.db.Entities;
using SalesApp.lib.Base;
using SalesApp.lib.DTOs;
using SalesApp.lib.DTOs.Carts;

namespace SalesApp.API.Services
{
    public class CartService(ICart repo, IMapper mapper, IGeneralRepo<Product> productRepo
        , IPaymentMethodService paymentMethod, IPaymentService service) : ICartService
    {
        public async Task<ResponseDto> DoCheckout(CheckoutDto checkout, string userId)
        {
            var (products, amount) = await GetCartAmount(checkout.Carts);
            var payMethods = await paymentMethod.GetPaymentMehod();
            if(paymentMethod != null && checkout.PaymentMethodId == payMethods.FirstOrDefault()!.Id)
            {
                var result = await service.PayMoney(amount, products, checkout.Carts);
                return result;
            }
            return new ResponseDto(false, "something is wrong, please try again.");
        }


        private async Task<(IEnumerable<Product>, decimal)> GetCartAmount(IEnumerable<CartDto> carts)
        {
            if(!carts.Any()) return ([],0);
            var products = await productRepo.GetAllAsync();
            if(!products.Any()) return ([],0);
            var cartPros = carts.Select(i => products.FirstOrDefault(p => p.Id == i.ProductId)).Where(p => p != null).ToList();

            var totalAmount = carts.Where(i => cartPros.Any(p => p.Id == i.ProductId)).Sum(i => i.Quantity * (cartPros.FirstOrDefault(p => p.Id == i.ProductId)?.Price ?? 0));

            return (cartPros!, totalAmount);
        }
        
        public async Task<ResponseDto> SaveCheckoutHistory(IEnumerable<ProductHistryDto> checkouts)
        {
            var mappedData = mapper.Map<IEnumerable<ProductHistory>>(checkouts);
            var result = await repo.SaveCheckoutHistory(mappedData);
            ResponseDto response = new ResponseDto(true, "Checkout history saved successfully.");
            if(result <= 0)
            {
                response = new ResponseDto(false, "Failed to save checkout history.");
            }
            return response;
        }
    }


}