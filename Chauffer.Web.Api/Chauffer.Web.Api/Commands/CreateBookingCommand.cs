using Chauffer.Web.Api.Models;
using System;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Commands
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private IChaufferDbContext context;
        public CreateBookingCommand(IChaufferDbContext context)
        {
            this.context = context;
        }

        public async Task<Booking> Execute(BookingBindingModel model)
        {
            var newBooking = new Booking
            {
                BookingId = Guid.NewGuid().ToString(),
                CustomerId = model.CustomerId,
                DriverId = model.DriverId,
                CreatedDate = DateTime.UtcNow.AddHours(1),
                StartDate = model.StartDate,
                StartAddress = model.StartAddress,
                StartPostCode = model.StartPostCode,
                EndAddress = model.EndAddress,
                EndPostCode = model.EndPostCode,
                CompletedDate = model.CompletedDate,
                JobType = model.JobType,
                ExtraInformation = model.ExtraInformation
            };

            context.Bookings.Add(newBooking);

            await context.SaveChangesAsync();

            return newBooking;
        }
    }

    public interface ICreateBookingCommand
    {
        Task<Booking> Execute(BookingBindingModel model);
    }
}