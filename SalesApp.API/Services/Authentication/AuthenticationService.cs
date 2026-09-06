using AutoMapper;
using Base.Authentication;
using DTOs.Identity;
using Entities.Identity;
using FluentValidation;
using SalesApp.API.Base;
using SalesApp.lib.Base;
using SalesApp.lib.DTOs;

namespace Services.Authentication
{
    public class AuthenticationService(ITokenManagement tokenManagement, IUserManagement userManagement
        ,IRoleManagement roleManagement, IAppLoger<AuthenticationService> logger, IMapper mapper,
        IValidator<CreateUser> createValidator, IValidator<LogInUser> logInUserValidator
        ,IValidationServices validationServices) : IAuthenticationService
    {
        public async Task<ResponseDto> CreateUser(CreateUser user)
        {
            var _validationResult = await validationServices.ValidationAsync(user, createValidator);
            if(!_validationResult.success) return _validationResult;

            var mapperModel = mapper.Map<AppUser>(user);
            mapperModel.UserName = user.Email;
            mapperModel.PasswordHash = user.Password;
            var result = await userManagement.CreateUser(mapperModel);
            if(!result) return new ResponseDto{
                message = "User creation failed"
            };

            var _user = await userManagement.GetUserByEmail(user.Email);
            var users = await userManagement.GetAllUsers();
            bool  assignResult = await roleManagement.AddUserToRole(_user!, users.Count() > 1? "User" : "Admin");

            if (!assignResult)
            {
                int removeUser = await userManagement.RemoveUserById(_user!.Email!);
                if(removeUser <= 0)
                {
                    logger.LogError(new Exception($"User Error in use Email{_user!.Email!}"), "User Error");
                    return new ResponseDto{ message =  "can't create new user account"};
                }
            }
            
            return new ResponseDto{success = true, message = "user account has been created"};
            
        }

        public async Task<LogInResponseDto> LogInUser(LogInUser user)
        {
            var _validationResult = await validationServices.ValidationAsync(user, logInUserValidator);
            if(!_validationResult.success) return new LogInResponseDto(false, _validationResult.message);

            var mapperModel = mapper.Map<AppUser>(user);
            mapperModel.PasswordHash = user.Password;

            bool loginResult = await userManagement.LogInUser(mapperModel);
            if(!loginResult) return new LogInResponseDto{message = "invalid user credint"};

            var _user = await userManagement.GetUserByEmail(user.Email);
            var claims = await userManagement.GetUserClaims(user.Email);

            string jwtToken = tokenManagement.GenerateToken(claims);
            string refreshToken = tokenManagement.GetRefreshToken();

            //int saveTokenResult = await tokenManagement.AddRefreshToken(_user!.Id, refreshToken);

            int saveTokenResult = 0;
            bool userCurrentToken = await tokenManagement.ValidateRefreshToken( refreshToken);
            if (userCurrentToken)
            {
                saveTokenResult = await tokenManagement.UpdateRefreshToken(_user!.Id, refreshToken);
            }
            else
            {
                saveTokenResult = await tokenManagement.AddRefreshToken(_user!.Id, refreshToken);
            }
            return saveTokenResult <= 0 ?  new LogInResponseDto{message = "Internal Srever Error"} 
            : new LogInResponseDto{success = true, Token = jwtToken, RefreshToken = refreshToken};

        }

        public async Task<LogInResponseDto> RetriveToken(string refreshToken)
        {
            bool validateTokenResult = await tokenManagement.ValidateRefreshToken(refreshToken);

            if(!validateTokenResult) return new LogInResponseDto{message = "Invalid Token"};

            string userId = await tokenManagement.GetUserIdByRefreshToken(refreshToken);
            AppUser? appUser = await userManagement.GetUserById(userId);

            var claims = await userManagement.GetUserClaims(appUser!.Email!);
            string newJwtToken = tokenManagement.GenerateToken(claims);
            string newRefreshToken = tokenManagement.GetRefreshToken();
            await tokenManagement.UpdateRefreshToken(userId, newRefreshToken);
            return new LogInResponseDto{ success = true, Token = newJwtToken, RefreshToken = newRefreshToken};

        }
    }
}