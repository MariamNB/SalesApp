using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Identity;

namespace Base.Authentication
{
    public interface IRoleManagement
    {
        Task<string?> GetUserRole(string userEmail);
        Task<bool> AddUserToRole(AppUser user, string roleName);
        //Task<bool> UserHasRole(string userEmail, string roleName);
    }
}