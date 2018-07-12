using Chauffer.Web.Api.Exceptions;
using Chauffer.Web.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Commands
{
    public class CancelBookingCommand : ICancelBookingCommand
    {
        private IChaufferDbContext context;
        public CancelBookingCommand(IChaufferDbContext context)
        {
            this.context = context;
        }

        public async Task<Booking> Execute(string bookingId)
        {
            var currentBooking = context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (currentBooking == null) throw new BookingNotFoundException("Booking not found");

            currentBooking.CancelledDate = DateTime.UtcNow.AddHours(1);

            await context.SaveChangesAsync();

            return currentBooking;
        }
    }

    public interface ICancelBookingCommand
    {
        Task<Booking> Execute(string bookingId);
    }
}