using System.Web.Mvc;

namespace CoreSuite.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },

            namespaces: new[] { "CoreSuite.Areas.Admin.Controllers" } // Namespace کنترلرهای Area
                );


            //            context.MapRoute(
            //name: "Admin",
            //url: "Admin/{controller}/{action}/{id}",
            //defaults: new { action = "Index", id = UrlParameter.Optional },
            //namespaces: new[] { "CoreSuite.Areas.Admin.Controllers" } // Namespace کنترلرهای Area
            //);

        }
    }
}