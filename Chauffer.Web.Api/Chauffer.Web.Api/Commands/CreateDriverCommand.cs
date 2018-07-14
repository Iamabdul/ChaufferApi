using Chauffer.Web.Api.Models;
using System;
using System.Threading.Tasks;

namespace Chauffer.Web.Api.Commands
{
    public class CreateDriverCommand : ICreateDriverCommand
    {
        private IChaufferDbContext context;
        public CreateDriverCommand(IChaufferDbContext context)
        {
            this.context = context;
        }

        public async Task<Driver> Execute(Driver model)
        {
            var newDriver = new Driver
            {
                DriverId = Guid.NewGuid().ToString(),
                Address = model.Address,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PreferredName = model.PreferredName,
                PostCode = model.PostCode,
                PhoneNumber = model.PhoneNumber,
                LicenceNumber = model.LicenceNumber,
                CarDetails = model.CarDetails,
                CarType = model.CarType,
                IsActive = true
            };

            context.Dirvers.Add(newDriver);
            await context.SaveChangesAsync();

            return newDriver;
        }
    }

    public interface ICreateDriverCommand
    {
        Task<Driver> Execute(Driver model);
    }
}