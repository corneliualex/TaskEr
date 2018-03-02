using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using System.Web.Mvc;
using TaskEr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskEr.ApplicationHelpers;

namespace TaskEr.ApplicationHelpers
{
    [Authorize]
    public class LoggedInUser : Controller, ILoggedInUser<ApplicationUser,IdentityUserRole>
    {
        #region fields & constructors
        private UserManager<ApplicationUser> _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly HttpContext _httpContext;
       
        public LoggedInUser(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        #endregion

        #region ILoggedInUser interface 
       
        public string GetUserId()
        {
            return _httpContext.User.Identity.GetUserId();
        }

        public ApplicationUser GetUser()
        {
            return _userManager.FindById(GetUserId());
        }

        public ICollection<IdentityUserRole> GetUserRoles()
        {
            return GetUser().Roles;
        }

        public IEnumerable<string> GetUserRolesByName()
        {
            var rolesList = new List<string>();
            foreach (var item in GetUserRoles())
            {
                var role = _context.Roles.Single(r => r.Id.Equals(item.RoleId));
                rolesList.Add(role.Name);
            }
            return rolesList;
        }

        #endregion
    }

    internal interface ILoggedInUser<TUser,TUserRole> 
        where TUser : ApplicationUser
        where TUserRole : IdentityUserRole
    {
        string GetUserId();

        TUser GetUser();

        ICollection<TUserRole> GetUserRoles();

        IEnumerable<string> GetUserRolesByName();
    }
}