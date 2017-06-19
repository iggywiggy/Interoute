using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace InterouteWebAPI
{
    public class ValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
        }
    }
}