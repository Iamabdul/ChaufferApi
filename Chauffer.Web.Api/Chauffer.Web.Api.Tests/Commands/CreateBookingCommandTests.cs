using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Chauffer.Web.Api.Tests.Commands
{
    public class CreateBookingCommandTests
    {
        private CreateBookingCommand sut;
        private readonly Mock<IChaufferDbContext> context = new Mock<IChaufferDbContext>();
        private TestDbSet<Booking> bookingSet = new TestDbSet<Booking>();

        public CreateBookingCommandTests()
        {
            context.Setup(c => c.Bookings).Returns(bookingSet);
            sut = new CreateBookingCommand(context.Object);
        }

        [Fact]
        public async Task CanCreateDriver()
        {
            await sut.Execute(CommonDataSet.BookingBindingModel);
            Assert.Equal(1, context.Object.Bookings.Local.Count);
            context.Verify(x => x.SaveChangesAsync(), Times.Once());
        }
    }
}
