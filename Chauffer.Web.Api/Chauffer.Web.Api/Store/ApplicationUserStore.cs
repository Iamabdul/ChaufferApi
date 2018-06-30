using Chauffer.Web.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Store
{
    public class ApplicationUserStore : UserStore<ApplicationUser>, IApplicationUserStore
    {
        private readonly ApplicationDbContext context;

        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public Task<ApplicationUser> FindByPhoneNumberAsync(string phoneNumber)
        {
            return this.context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }
    }

    public interface IApplicationUserStore : IUserStore<ApplicationUser>
    {
        IQueryable<ApplicationUser> Users { get; }
        Task<ApplicationUser> FindByPhoneNumberAsync(string phoneNumber);
    }
}