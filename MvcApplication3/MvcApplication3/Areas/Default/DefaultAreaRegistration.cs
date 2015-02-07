using System.Web.Mvc;

namespace MvcApplication3.Areas.Default
{
    public class DefaultAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Default";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
              context.MapRoute(
                  name : "default",
                  url : "{controller}/{action}/{id}",
                  defaults : new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces : new[] { "MvcApplication3.Areas.Default.Controllers" }
              ); 

              context.MapRoute(
                    name: "Role",
                    url: "roli/{action}/{id}",
                    defaults: new { controller = "Role", action = "Role", id = UrlParameter.Optional },
                    constraints: new { id = @"\d+" },
                    namespaces : new[] { "MvcApplication3.Areas.Default.Controllers" }
                );

              context.MapRoute(
                      name: "User",
                      url: "user/{action}/{id}",
                      defaults: new { controller = "User", action = "UserActionResult", id = UrlParameter.Optional },
                      constraints: new { id = @"\d+" },
                      namespaces: new[] { "MvcApplication3.Areas.Default.Controllers" }
                  );
        }
    }
}
