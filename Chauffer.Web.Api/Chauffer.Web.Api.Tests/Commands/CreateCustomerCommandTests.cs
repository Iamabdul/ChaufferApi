using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Chauffer.Web.Api.Tests.Commands
{
    public class CreateCustomerCommandTests
    {
        private CreateCustomerCommand sut;
        private readonly Mock<IChaufferDbContext> context = new Mock<IChaufferDbContext>();
        private TestDbSet<Customer> customerSet = new TestDbSet<Customer>();

        public CreateCustomerCommandTests()
        {
            context.Setup(c => c.Customers).Returns(customerSet);

            sut = new CreateCustomerCommand(context.Object);
        }

        [Fact]
        public async Task CanCreateCustomer()
        {
            await sut.Execute(CommonDataSet.registerBindingModel);
            Assert.Equal(1, context.Object.Customers.Local.Count);
            context.Verify(x => x.SaveChangesAsync(), Times.Once());
        }
    }
}
