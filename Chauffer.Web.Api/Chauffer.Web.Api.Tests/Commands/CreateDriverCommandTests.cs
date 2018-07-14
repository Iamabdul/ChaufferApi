using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Chauffer.Web.Api.Tests.Commands
{
    public class CreateDriverCommandTests
    {
        private CreateDriverCommand sut;
        private readonly Mock<IChaufferDbContext> context = new Mock<IChaufferDbContext>();
        private TestDbSet<Driver> driverSet = new TestDbSet<Driver>();

        public CreateDriverCommandTests()
        {
            context.Setup(c => c.Dirvers).Returns(driverSet);

            sut = new CreateDriverCommand(context.Object);
        }

        [Fact]
        public async Task CanCreateDriver()
        {
            await sut.Execute(CommonDataSet.commonDriver);
            Assert.Equal(1, context.Object.Dirvers.Local.Count);
            context.Verify(x => x.SaveChangesAsync(), Times.Once());
        }
    }
}
