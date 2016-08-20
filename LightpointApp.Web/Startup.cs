using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Reflection;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using LightpointApp.DataAccess.Contexts;
using System.Configuration;
using LightpointApp.BusinessLogic.Interfaces;
using LightpointApp.BusinessLogic.Providers;
using System.Data.Entity;
using LightpointApp.DataAccess.Initializers;

[assembly: OwinStartup(typeof(LightpointApp.Web.Startup))]

namespace LightpointApp.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new DropCreateSeedDatabaseAlways());

            var webApiConfig = ConfigureWebApi();

            app.UseErrorPage();
            app.UseDefaultFiles(new DefaultFilesOptions()
            {
                DefaultFileNames = new List<string> { "App/views/index.html" }
            });
            app.UseStaticFiles();
            app.UseNinjectMiddleware(CreateKernel);
            app.UseNinjectWebApi(webApiConfig);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            return config;
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var connectionString = ConfigurationManager.ConnectionStrings["LightpointDatabase"].ConnectionString;

            kernel.Bind<LightpointContext>().ToSelf().InTransientScope().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IShopProvider>().To<ShopProvider>().InTransientScope();
            kernel.Bind<IProductProvider>().To<ProductProvider>().InTransientScope();

            return kernel;
        }
    }
}
