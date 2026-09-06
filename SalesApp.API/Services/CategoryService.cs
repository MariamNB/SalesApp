using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SalesApp.API.Base;
using SalesApp.db.Base;
using SalesApp.db.Base.Products;
using SalesApp.db.Entities;
using SalesApp.lib.DTOs;

namespace SalesApp.lib.Services
{
    public class CategoryService(IGeneralRepo<Category> category, IMapper mapper
        ,ICategory categorySrv) : ICategoryService
    {
        public async Task<ResponseDto> AddAsync(CategoryDto entity)
        {
            try
            {
                var mappData = mapper.Map<Category>(entity);
                int result = await category.AddAsync(mappData);
                if(result > 0)
                {
                    return new ResponseDto(true, "success!");
                }
            }
            catch(Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "server can't save the category!");
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            try
            {
                int result = await category.DeleteAsync(id);
                if(result > 0)
                {
                    return new ResponseDto(true, "success!");
                }
                
            }
            catch(Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "server can't delete!");
        }

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            try
            {
                var data = await category.GetAllAsync();
                if(data == null || !data.Any()) return [];
                return mapper.Map<IEnumerable<GetCategoryDto>>(data);
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetCategoryDto> GetById(Guid id)
        {
            try
            {
                var data = await category.GetById(id);
                if(data == null) return new GetCategoryDto();
                return mapper.Map<GetCategoryDto>(data);
            }
            catch
            {
                return new GetCategoryDto();
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProductsWithCategory(Guid id)
        {
            var products = await categorySrv.GetProductsWithCategory(id);
            if (!products.Any()) return [];

            return mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public async Task<ResponseDto> UpdateAsync(UpdateCategoryDTO entity)
        {
             try
            {
                var mappData = mapper.Map<Category>(entity);
                int result = await category.UpdateAsync(mappData);
                if(result > 0)
                {
                    return new ResponseDto(true, "success!");
                }
            }
            catch(Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "server can't update the category!");
        }
    }
}