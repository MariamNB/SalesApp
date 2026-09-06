using Microsoft.AspNetCore.Mvc;
using SalesApp.API.Base;
using SalesApp.lib.DTOs;
using SalesApp.lib.DTOs.Carts;

namespace SalesApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CartController (ICartService cartService): Controller
    {
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CheckoutDto checkout)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await cartService.DoCheckout(checkout, "0");
                return result.success? Ok(result) : BadRequest(result);
            }
        }

        [HttpPost("saveCheckout")]
        public async Task<IActionResult> SaveCheckout(IEnumerable<ProductHistryDto> historydto)
        {
            var result = await cartService.SaveCheckoutHistory(historydto);
            return result.success? Ok(result) : BadRequest(result);
        }
    }
}