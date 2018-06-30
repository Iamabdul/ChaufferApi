using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Chauffer.Web.Api.App_Start;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Chauffer.Web.Api.Startup))]

namespace Chauffer.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureContainerScope(app);
            ConfigureContainer(app);


            var configuration = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(ContainerConfig.Container)
            };

            WebApiConfig.Register(configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //var container = SimpleInjectorInitializer.Initialize(app);
            ConfigureAuth(app);
            app.UseWebApi(configuration);
        }

        private void ConfigureContainer(IAppBuilder app)
        {
            ContainerConfig.Configure();
            ContainerConfig.Container.Verify();
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(ContainerConfig.Container))
                {
                    await next();
                }
            });
        }

        private void ConfigureContainerScope(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(ContainerConfig.Container))
                {
                    await next();
                }
            });
        }
    }
}
