using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebResurection.Repositories.EF;
using System.Data.Entity.Infrastructure.Interception;

namespace WebResurection
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //DbInterception.Add(new WebResInterceptorTransientErrors());//by using the new keyword this becomes tightly coupled with the Repositorie.Ef
            DbInterception.Add(new WebResurectionInterceptorLogging());//Maybe consider making a method thats simply GetTransientErrors, GetLogging so that all I have to do is
                                                                       //implement those methods in whatever I reference in the using statement 
        }
    }
}
