using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZapatosABCDataLibrary.Data;
using ZapatosABCDataLibrary.DataAccess;

[assembly: OwinStartupAttribute(typeof(ZapatosABCLoginCrearProducto.Startup))]
namespace ZapatosABCLoginCrearProducto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var services = new ServiceCollection();
            ConfigureAuth(app);
            ConfigureServices(services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
            .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
            .Where(t => typeof(IController).IsAssignableFrom(t)
      || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));

            services.AddSingleton(new ConnectionStringData
            {
                SqlConnectionName = "Default"
            });
            services.AddSingleton<IDataAccess, SqlDb>();
            services.AddSingleton<IProductData, ProductData>();

        }


    }
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddControllersAsServices(this IServiceCollection services,
           IEnumerable<Type> controllerTypes)
        {
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            return services;
        }
    }

}
