using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SalesApp.API.Base;
using SalesApp.lib.DTOs;

namespace Services.Authentication
{
    public class ValidationServices : IValidationServices
    {
        public async Task<ResponseDto> ValidationAsync<T>(T model, IValidator<T> validator)
        {
             var _validator = await validator.ValidateAsync(model);
            if (!_validator.IsValid)
            {
                var errors = _validator.Errors.Select(e => e.ErrorMessage).ToList();
                string errorMessage = string.Join(", ", errors);
                return new ResponseDto{
                   message = errorMessage
                };
            }
            return new ResponseDto{
                success = true,
                message = "Validation successful"
            };
        }
    }
}