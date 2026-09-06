using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Authentication;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Repos.Authentication
{
    public class RoleManagement(UserManager<AppUser> userManager) : IRoleManagement
    {
        public async Task<bool> AddUserToRole(AppUser user, string roleName)
        {
            return(await userManager.AddToRoleAsync(user, roleName)).Succeeded;
        }

        public async Task<string?> GetUserRole(string userEmail)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            return(await userManager.GetRolesAsync(user!)).FirstOrDefault();
        }

    }
}