using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApp.lib.DTOs;

namespace SalesApp.API.Base
{
    public interface ICategoryService
    {
         Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetById(Guid id);
        Task<ResponseDto> AddAsync(CategoryDto entity);
        Task<ResponseDto> UpdateAsync(UpdateCategoryDTO entity);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}