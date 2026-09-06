using DTOs.Identity;
using Microsoft.AspNetCore.Mvc;
using IAuthenticationService = SalesApp.API.Base.IAuthenticationService;

namespace SalesApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController (IAuthenticationService service): ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(CreateUser user)
        {
            var result = await service.CreateUser(user);
            return result.success? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogInUser(LogInUser user)
        {
            var result = await service.LogInUser(user);
            return result.success? Ok(result) : BadRequest(result);
        }

        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
        {
            var result = await service.RetriveToken(refreshToken);
            return result.success? Ok(result) : BadRequest(result);
        }
        
    }
}