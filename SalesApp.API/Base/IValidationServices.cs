using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SalesApp.lib.DTOs;

namespace SalesApp.API.Base
{
    public interface IValidationServices
    {
        Task<ResponseDto> ValidationAsync<T>(T model, IValidator<T> validator);
    }
}