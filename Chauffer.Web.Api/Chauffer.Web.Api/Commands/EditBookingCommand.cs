using Chauffer.Web.Api.Exceptions;
using Chauffer.Web.Api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Commands
{
    public class EditBookingCommand : IEditBookingCommand
    {
        private IChaufferDbContext context;
        public EditBookingCommand(IChaufferDbContext context)
        {
            this.context = context;
        }

        public async Task<Booking> Execute(BookingBindingModel model)
        {
            var currentBooking = context.Bookings.FirstOrDefault(b => b.BookingId == model.BookingId);

            if (currentBooking == null) throw new BookingNotFoundException("Booking not found");


            currentBooking.DriverId = model.DriverId;
            currentBooking.StartAddress = model.StartAddress;
            currentBooking.StartPostCode = model.StartPostCode;
            currentBooking.EndAddress = model.EndAddress;
            currentBooking.EndPostCode = model.EndPostCode;
            currentBooking.CompletedDate = model.CompletedDate ?? null;
            currentBooking.JobType = model.JobType ?? null;
            currentBooking.ExtraInformation = model.ExtraInformation;

            context.SaveChanges();

            return currentBooking;
        }
    }

    public interface IEditBookingCommand
    {
        Task<Booking> Execute(BookingBindingModel model);
    }
}