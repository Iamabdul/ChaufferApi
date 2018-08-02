using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chauffer.Web.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Drivers")]
    public class DriversController : ApiController
    {
        IChaufferDbContext context;
        ICreateDriverCommand createDriverCommand;

        public DriversController(ICreateDriverCommand createDriverCommand, IChaufferDbContext context)
        {
            this.context = context;
            this.createDriverCommand = createDriverCommand;
        }

        public IQueryable<Driver> GetAllDrivers()
        {
            return context.Dirvers.OrderByDescending(dr => dr.LastBookingDate);
        }

        [Route("ActiveInactive")]
        public IQueryable<Driver> GetActiveInactiveDrivers([FromUri] bool isActive)
        {
            return context.Dirvers.Where(d => d.IsActive == isActive).OrderByDescending(dr => dr.LastBookingDate);
        }
    }
}
