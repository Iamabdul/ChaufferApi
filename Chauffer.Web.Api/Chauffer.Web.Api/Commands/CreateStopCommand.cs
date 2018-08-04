using Chauffer.Web.Api.Exceptions;
using Chauffer.Web.Api.Helpers;
using Chauffer.Web.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Commands
{
    public class CreateStopCommand : ICreateStopCommand
    {
        private IChaufferDbContext context;
        public CreateStopCommand(IChaufferDbContext context)
        {
            this.context = context;
        }

        public async Task Execute(StopBindingModel model)
        {
            var booking = context.Bookings.FirstOrDefault(b => b.BookingId == model.BookingId);
            if (booking == null)
                throw new BookingNotFoundException("Booking Not Found");

            var driver = context.Dirvers.FirstOrDefault(d => d.DriverId == booking.DriverId);
            if (driver == null)
                throw new DriverNotFoundException("Driver Not Found");

            var newStop = new Stop
            {
                StopId = Guid.NewGuid().ToString(),
                BookingId = booking.BookingId,
                Address = model.Address,
                PostCode = model.PostCode,
                Reason = model.Reason,
                Date = model?.Date ?? DateTime.UtcNow.AddHours(1),
                Charge = model.Reason.ToStopCharge(driver.CarType, booking.JobType)
            };

            context.Stops.Add(newStop);

            await context.SaveChangesAsync();
        }
    }

    public interface ICreateStopCommand
    {
        Task Execute(StopBindingModel model);
    }
}