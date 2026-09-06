using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Base.Authentication;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesApp.db.Contexts;

namespace Repos.Authentication
{
    public class UserManagement (IRoleManagement roleManagement, UserManager<AppUser> userManager, AppDbContext context): IUserManagement
    {
        public async Task<bool> CreateUser(AppUser user)
        {
            var _user = await GetUserByEmail(user.Email!);
            if (_user != null)
            {
                return false;
            }
            return (await userManager.CreateAsync(user, user.PasswordHash!)).Succeeded;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<AppUser?> GetUserByEmail(string UserEmail)
        {
            return await userManager.FindByEmailAsync(UserEmail);
        }

        public  async Task<AppUser?> GetUserById(string UserId)
        {
            var user = await userManager.FindByIdAsync(UserId);
            return user;
        }

        public async Task<List<Claim>> GetUserClaims(string userEmail)
        {
            var _user = await GetUserByEmail(userEmail);
            string? roleName = await roleManagement.GetUserRole(_user!.Email!);
            List<Claim> claims = [
                new Claim("fullName", _user.fullName!),
                new Claim(ClaimTypes.NameIdentifier, _user.Id),
                new Claim(ClaimTypes.Email, _user.Email!),
                new Claim(ClaimTypes.Role, roleName!)
            ];
            return claims;
        }

        public async Task<bool> LogInUser(AppUser user)
        {
            var _user = await GetUserByEmail(user!.Email!);
            if(_user == null) return false;

            var roleName = await roleManagement.GetUserRole(_user.Email!);
            if(string.IsNullOrEmpty(roleName)) return false;

            return await userManager.CheckPasswordAsync(_user, user.PasswordHash!);
        }

        public async Task<int> RemoveUserById(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == userId);
            context.Users.Remove(user!);
            return await context.SaveChangesAsync();
            // throw new NotImplementedException();
        }
    }
}