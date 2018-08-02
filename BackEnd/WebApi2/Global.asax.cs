using System.Web.Http;

namespace WebApi2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IocConfig.Register();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
