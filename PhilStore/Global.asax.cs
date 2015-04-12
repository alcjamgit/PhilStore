using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PhilStore.App_Start;
using PhilStore.DependencyResolvers;

namespace PhilStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //setup Ioc Containers
            var controllerFactory = new IocControllerFactory(UnityConfig.RegisterTypes());
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
