using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Chauffer.Web.Api.Tests.Commands
{
    public class CreateStopCommandTests
    {
        private CreateStopCommand sut;
        private readonly Mock<IChaufferDbContext> context = new Mock<IChaufferDbContext>();
        private TestDbSet<Stop> stopsSet = new TestDbSet<Stop>();
        private TestDbSet<Booking> bookingsSet = new TestDbSet<Booking>();
        private TestDbSet<Driver> driversSet = new TestDbSet<Driver>();

        public CreateStopCommandTests()
        {
            bookingsSet.Add(CommonDataSet.CommonBooking);
            driversSet.Add(CommonDataSet.CommonDriver);
            context.Setup(c => c.Stops).Returns(stopsSet);
            context.Setup(c => c.Bookings).Returns(bookingsSet);
            context.Setup(c => c.Dirvers).Returns(driversSet);
            sut = new CreateStopCommand(context.Object);
        }

        [Fact]
        public async Task CanCreateDriver()
        {
            await sut.Execute(CommonDataSet.StopBindingModel);
            Assert.Single(context.Object.Stops);
            context.Verify(x => x.SaveChangesAsync(), Times.Once());
        }
    }
}
