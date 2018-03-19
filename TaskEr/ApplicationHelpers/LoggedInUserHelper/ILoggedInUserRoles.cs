using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEr.ApplicationHelpers.LoggedInUserHelper
{
    //Helper methods for getting details about the current logged in user
    internal interface ILoggedInUserRoles<TUserRole>
         where TUserRole : IdentityUserRole
    {
        ICollection<TUserRole> GetUserRoles();
        IEnumerable<string> GetUserRolesByName();
    }
}
