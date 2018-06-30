using Chauffer.Web.Api.Commands;
using Chauffer.Web.Api.Managers;
using Chauffer.Web.Api.Models;
using Chauffer.Web.Api.Store;
using Microsoft.Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace Chauffer.Web.Api.App_Start
{
    public class ContainerConfig
    {
        public static Container Container { get; private set; }

        public static void Configure()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            RegisterServices(Container);
        }
        private static void RegisterServices(Container container)
        {
            BindCommands(container);
            BindQueries(container);
            BindOwin(container);
            BindStores(container);
            BindManagers(container);
            BindApplicationServices(container);
            BindEsb(container);
            container.RegisterInstance<IOwinContextAccessor>(new CallContextOwinContextAccessor());

        }

        private static void BindEsb(Container container)
        {
        }

        private static void BindApplicationServices(Container container)
        {
            var dbContextRegistration = Lifestyle.Scoped.CreateRegistration<ApplicationDbContext>(container);
            container.AddRegistration<IChaufferDbContext>(dbContextRegistration);
            container.AddRegistration<ApplicationDbContext>(dbContextRegistration);
        }

        private static void BindManagers(Container container)
        {
            //var userManagerRegistration = Lifestyle.Scoped.CreateRegistration<EnhancedApplicationUserManager>(container);
            container.Register<EnhancedApplicationUserManager>(Lifestyle.Scoped);

            container.Register<IHttpContextAccessor, HttpContextAccessor>(Lifestyle.Scoped);
        }

        private static void BindStores(Container container)
        {
            container.Register<IApplicationUserStore, ApplicationUserStore>(Lifestyle.Scoped);
        }

        private static void BindOwin(Container container)
        {

        }

        private static void BindQueries(Container container)
        {
        }

        private static void BindCommands(Container container)
        {
            container.Register<ICreateCustomerCommand, CreateCustomerCommand>(Lifestyle.Scoped);
        }

        public interface IOwinContextAccessor
        {
            IOwinContext CurrentContext { get; }
        }

        public class CallContextOwinContextAccessor : IOwinContextAccessor
        {
            public static AsyncLocal<IOwinContext> OwinContext = new AsyncLocal<IOwinContext>();
            public IOwinContext CurrentContext => OwinContext.Value;
        }

        public interface IHttpContextAccessor
        {
            HttpRequestWrapper Get();
        }
        public class HttpContextAccessor : IHttpContextAccessor
        {
            public HttpRequestWrapper Get()
            {
                return new HttpRequestWrapper(HttpContext.Current.Request);
            }
        }
    }
}