using Microsoft.AspNetCore.Mvc;
using SalesApp.lib.Base;
using SalesApp.lib.DTOs;

namespace SalesApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController (IProductService srvProduct): ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await srvProduct.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : NotFound();
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await srvProduct.GetById(id);
            return result != null ? Ok(result) : NotFound(id);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNew(ProductDto item)
        {
            var result = await srvProduct.AddAsync(item);
            return result != null ? Ok(result) : BadRequest(item);

        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateProductDto item)
        {
            var result = await srvProduct.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvProduct.DeleteAsync(id);
            return result != null ? Ok(result) : BadRequest(id);
        }

    }
}