using Microsoft.AspNetCore.Mvc;
using SalesApp.API.Base;
using SalesApp.db.Entities;
using SalesApp.lib.DTOs;

namespace SalesApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryService srvCategory): ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await srvCategory.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : NotFound();
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await srvCategory.GetById(id);
            return result != null ? Ok(result) : NotFound(id);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNew(CategoryDto item)
        {
            var result = await srvCategory.AddAsync(item);
            return result != null ? Ok(result) : BadRequest(item);

        }
        
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateCategoryDTO item)
        {
            var result = await srvCategory.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(item);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvCategory.DeleteAsync(id);
            return result != null ? Ok(result) : BadRequest(id);
        }
        
    }
}