using Chauffer.Web.Api.Models;
using Chauffer.Web.Api.Store;
using Microsoft.AspNet.Identity;

namespace Chauffer.Web.Api.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IApplicationUserStore store)
            : base(store)
        {
        }
    }
}