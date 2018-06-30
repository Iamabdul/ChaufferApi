using Chauffer.Web.Api.Models;
using Chauffer.Web.Api.Store;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Chauffer.Web.Api.Managers
{
    public class EnhancedApplicationUserManager : ApplicationUserManager
    {
        private readonly IApplicationUserStore store;

        public EnhancedApplicationUserManager(IApplicationUserStore store) : base(store)
        {
            this.store = store;
        }

        public Task<ApplicationUser> FindByPhoneNumber(string phoneNumber)
        {
            return store.FindByPhoneNumberAsync(phoneNumber);
        }

        public async Task ChangePasswordAsync(ApplicationUser user, string newPassword)
        {
            var passwordStore = Store as IUserPasswordStore<ApplicationUser, string>;

            if (passwordStore == null) return;

            await UpdatePassword(passwordStore, user, newPassword);

            await passwordStore.UpdateAsync(user);
        }

        public IQueryable<ApplicationUser> All()
        {
            return store.Users;
        }

        public static EnhancedApplicationUserManager Create(IdentityFactoryOptions<EnhancedApplicationUserManager> options, IOwinContext context)
        {
            var manager = new EnhancedApplicationUserManager(new ApplicationUserStore(context.Get<ApplicationDbContext>()));

            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }
}