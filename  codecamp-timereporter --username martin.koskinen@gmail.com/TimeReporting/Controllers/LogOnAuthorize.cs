using System.Web.Mvc;

namespace TimeReporting.Controllers
{
    public class LogonAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!(filterContext.Controller is AccountController))
                base.OnAuthorization(filterContext);
        }
    }
}
