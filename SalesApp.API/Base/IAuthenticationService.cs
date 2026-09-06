using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Identity;
using SalesApp.API.Base;
using SalesApp.lib.DTOs;

namespace SalesApp.API.Base
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> CreateUser(CreateUser user);
        Task<LogInResponseDto> LogInUser(LogInUser user);
        Task<LogInResponseDto> RetriveToken(string refreshToken);
    }
}