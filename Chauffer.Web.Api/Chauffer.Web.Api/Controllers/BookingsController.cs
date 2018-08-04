using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Chauffer.Web.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Bookings")]
    public class BookingsController : ApiController
    {
        IChaufferDbContext context;
        ICreateBookingCommand createBookingCommand;
        IEditBookingCommand editBookingCommand;
        ICreateStopCommand createStopCommand;

        public BookingsController
            (
            IChaufferDbContext context,
            ICreateBookingCommand createBookingCommand,
            IEditBookingCommand editBookingCommand,
            ICreateStopCommand createStopCommand
            )
        {
            this.context = context;
            this.createBookingCommand = createBookingCommand;
            this.editBookingCommand = editBookingCommand;
            this.createStopCommand = createStopCommand;
        }

        public IQueryable<Booking> GetAllBookings()
        {
            return context.Bookings.OrderByDescending(b => b.StartDate);
        }

        public IQueryable<Booking> GetActiveInactiveBookings([FromUri] bool isActive)
        {
            return context.Bookings.Where(d => (isActive == true ? d.CancelledDate == null : d.CancelledDate != null)).OrderByDescending(dr => dr.StartDate);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateBooking(BookingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await createBookingCommand.Execute(model);

            return Ok();
        }


        [Route("Edit")]
        [HttpPut]
        public async Task<IHttpActionResult> EditBooking(BookingBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await editBookingCommand.Execute(model);

            return Ok();
        }

        [Route("Stops")]
        [HttpGet]
        public IQueryable<Stop> GetAllStops()
        {
            return context.Stops.OrderByDescending(s => s.Date);
        }

        [Route("Stops/Create")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateStop(StopBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await createStopCommand.Execute(model);

            return Ok();
        }
    }
}
