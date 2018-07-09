using Chauffer.Web.Api.Models;
using System;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Commands
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private IChaufferDbContext context;
        public CreateCustomerCommand(IChaufferDbContext context)
        {
            this.context = context;
        }

        public async Task Execute(RegisterBindingModel model)
        {
            var newCustomer = new Customer
            {
                CustomerId = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.LastName,
                PostCode = model.PostCode,
                PreferredName = model.PreferredName,
                PhoneNumber = model.PhoneNumber,
                PreferredDriverUserId = model.PreferredDriverUserId,
                ExtraInformation = model.ExtraInformation
            };

            context.Customers.Add(newCustomer);
        }
    }

    public interface ICreateCustomerCommand
    {
        Task Execute(RegisterBindingModel user);
    }
}