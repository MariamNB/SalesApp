using DTOs.Payments;
using Microsoft.AspNetCore.Mvc;
using SalesApp.lib.Base;

namespace SalesApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController(IPaymentMethodService payService) : ControllerBase
    {

        [HttpGet("paymethods")]
        public async Task<ActionResult<IEnumerable<PaymentMehodDto>>> GetAllPaymentMethods()
        {
            var methods = await payService.GetPaymentMehod();
            if(methods.Any())
            {
                return NotFound();
            }
            return  Ok(methods);
        }
        
    }
}