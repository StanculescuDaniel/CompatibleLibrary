using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CompatibleLibrary;
using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplicationNetFram48
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            ContainerBuilder builder = new ContainerBuilder();
            IServiceCollection services = new ServiceCollection();
            services.AddCountriesClient();
            
            builder.Populate(services);
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            IContainer container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
