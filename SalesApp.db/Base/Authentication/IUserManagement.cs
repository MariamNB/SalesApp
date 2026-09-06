using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Identity;
using System.Security.Claims;

namespace Base.Authentication
{
    public interface IUserManagement
    {
        Task<bool> CreateUser(AppUser user);
        Task<bool> LogInUser(AppUser user);

        Task<AppUser?> GetUserByEmail(string UserEmail);
        Task<AppUser?> GetUserById(string UserId);

        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<int> RemoveUserById(string userId);
        Task<List<Claim>> GetUserClaims(string userEmail); 
    }
}