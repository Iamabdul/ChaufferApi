using Chauffer.Web.Api.Exceptions;
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

        public async Task Execute(StopModel model)
        {
            var booking = context.Bookings.FirstOrDefault(b => b.BookingId == model.BookingId);

            if (booking == null)
                throw new BookingNotFoundException();

            var newStop = new Stop
            {
                StopId = Guid.NewGuid().ToString(),
                BookingId = booking.BookingId,
                Address = model.Address,
                PostCode = model.PostCode,
                Reason = model.Reason
            };

            context.Stops.Add(newStop);

            await context.SaveChangesAsync();
        }
    }

    public interface ICreateStopCommand
    {
        Task Execute(StopModel model);
    }
}