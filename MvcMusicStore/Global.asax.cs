using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcMusicStore.Controllers;
using MvcMusicStore.Infrastructure;
using NLog;
using PerformanceCounterHelper;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            this.ConfigureDependencyInjector();
            this.InitPerformanceCounters();

            _logger.Info("Application started");
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            _logger.Error(exception.ToString());
        }

        private void ConfigureDependencyInjector()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterControllers(typeof(AccountController).Assembly);
            builder.Register(f => LogManager.GetLogger("ForControllers")).As<ILogger>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private void InitPerformanceCounters()
        {
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<PerformanceCounters>("MvcMusicStore"))
            {
                counterHelper.RawValue(PerformanceCounters.LogInCount, 0);
                counterHelper.RawValue(PerformanceCounters.LogOutCount, 0);
                counterHelper.RawValue(PerformanceCounters.HomePageHitCount, 0);
            }
        }
    }
}
