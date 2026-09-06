using SalesApp.lib.DTOs;
using SalesApp.lib.DTOs.Carts;

namespace SalesApp.API.Base
{
    public interface ICartService
    {
        Task<ResponseDto> SaveCheckoutHistory(IEnumerable<ProductHistryDto> checkouts);

        Task<ResponseDto> DoCheckout(CheckoutDto checkout, string userId);
    }
}