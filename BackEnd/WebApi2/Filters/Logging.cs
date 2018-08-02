using log4net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi2.Filters
{
    public class Logging : ActionFilterAttribute
    {
        private readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Log.InfoFormat(
                $"Request {actionContext.Request.Method} {actionContext.Request.RequestUri}");
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
                Log.InfoFormat(
                    $"{actionExecutedContext.Request.RequestUri} Response Code: {actionExecutedContext.Response.StatusCode}");
            else
                Log.ErrorFormat(
                    $"{actionExecutedContext.Request.RequestUri} Error Message: {actionExecutedContext.Exception.Message} Stack Trace: {actionExecutedContext.Exception.StackTrace}");
        }
    }
}