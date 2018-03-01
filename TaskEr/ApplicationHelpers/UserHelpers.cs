using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
using System.Web.Mvc;
using TaskEr.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskEr.ApplicationHelpers
{
    [Authorize]
    public class UserHelpers<T> : Controller, IUserHelpers where T : ApplicationUser
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private UserManager<ApplicationUser> _userManager;
        private HttpContext _httpContext;

        public UserHelpers(HttpContext httpContext)
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            _httpContext = httpContext;
        }

        public string GetCurrentUserId()
        {
            return _httpContext.User.Identity.GetUserId();
        }

        public ApplicationUser GetCurrentUser()
        {
            return _userManager.FindById(GetCurrentUserId());
        }

        public IEnumerable<string> GetCurrentUserRoles()
        {
            var rolesList = new List<string>();
            foreach (var item in GetCurrentUser().Roles)
            {
                rolesList = _context.Roles.Where(rid => rid.Id.Equals(item.RoleId)).Select(r => r.Name).ToList();   
            }
            return rolesList;
        }





        /*
public Task<string> GetUserId()
{
   var x = Task.FromResult<string>(_httpContext.User.Identity.GetUserId());
   return x;
}*/
    }

    internal interface IUserHelpers
    {
        string GetCurrentUserId();

        ApplicationUser GetCurrentUser();

        IEnumerable<string> GetCurrentUserRoles();
    }
}