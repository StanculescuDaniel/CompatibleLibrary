using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CompatibleLibrary;
using CompatibleLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationNetFram48
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);


            IServiceCollection services = new ServiceCollection();
            services.AddCountriesClient();
            var builder = new ContainerBuilder();
            builder.Populate(services);



            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            
            var container = builder.Build();

            using(var scope = container.BeginLifetimeScope())
            {
                var x = scope.Resolve<ICountriesServiceClient>();
            }
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
