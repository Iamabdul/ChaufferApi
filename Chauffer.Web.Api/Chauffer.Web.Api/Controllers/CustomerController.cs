using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace Chauffer.Web.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Customers")]
    public class CustomerController : ApiController
    {
        IChaufferDbContext context;
        ICreateCustomerCommand createCustomerCommand;

        public CustomerController(ICreateCustomerCommand createCustomerCommand, IChaufferDbContext context)
        {
            this.context = context;
            this.createCustomerCommand = createCustomerCommand;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(CustomerBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await createCustomerCommand.Execute(model);

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
