using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System;

namespace Chauffer.Web.Api.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IChaufferDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Driver> Dirvers { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Booking> Bookings { get; set; }
        public IDbSet<Stop> Stops { get; set; }

        public void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public void SetUpdated(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }

            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }


    public interface IChaufferDbContext
    {
        IDbSet<Driver> Dirvers { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<Booking> Bookings { get; set; }
        IDbSet<Stop> Stops { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
        void SetDeleted(object entity);
        void SetUpdated(object entity);
    }
}