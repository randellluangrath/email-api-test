﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using email_api_test.Utilities;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace email_api_test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();
            container.Register<IConfigurationUtility, ConfigurationUtility>();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}
