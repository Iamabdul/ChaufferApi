using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using System.Linq;
using System.Web.Http;

namespace Chauffer.Web.Api.Controllers
{
    [Authorize]
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

        public IQueryable<Booking> GetActiveInactiveBookings([FromUri] bool isActive)
        {
            return context.Bookings.Where(d => (isActive == true ? d.CancelledDate == null : d.CancelledDate != null)).OrderByDescending(dr => dr.StartDate);
        }

    }
}
