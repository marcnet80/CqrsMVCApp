using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CqrsApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static RuntimeCQRS Runtime { get; set; }

        protected void Application_Start()
        {
            Runtime = new RuntimeCQRS();
            Runtime.Start();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_End()
        {
            Runtime.Shutdown();
        }
    }
}
