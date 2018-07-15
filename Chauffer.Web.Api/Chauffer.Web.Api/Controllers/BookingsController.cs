using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using System.Linq;
using System.Web.Http;

namespace Chauffer.Web.Api.Controllers
{
    [RoutePrefix("api/Bookings")]
    public class BookingsController : ApiController
    {
        IChaufferDbContext context;
        ICreateBookingCommand createBookingCommand;

        public BookingsController(ICreateBookingCommand createBookingCommand, IChaufferDbContext context)
        {
            this.context = context;
            this.createBookingCommand = createBookingCommand;
        }

        public IQueryable<Booking> GetAllBookings()
        {
            return context.Bookings.OrderByDescending(b => b.StartDate);
        }

        [Route("ActiveInactive")]
        public IQueryable<Booking> GetActiveInactiveDrivers(ActiveInactiveModel model)
        {
            return context.Bookings.Where(d => (model.IsActive == true ? d.CancelledDate == null : d.CancelledDate != null)).OrderByDescending(dr => dr.StartDate);
        }
    }
}
