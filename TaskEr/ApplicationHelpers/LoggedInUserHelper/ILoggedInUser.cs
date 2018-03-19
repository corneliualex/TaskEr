using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEr.Models;

namespace TaskEr.ApplicationHelpers.LoggedInUserHelper
{
    //Helper methods for getting details about the current logged in user
    internal interface ILoggedInUser<TUser>
        where TUser : ApplicationUser
    {
        string GetUserId();
        string GetUsername();
        TUser GetUser();

    }
}
