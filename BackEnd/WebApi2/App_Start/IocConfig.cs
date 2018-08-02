using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebApi2.Services.DataUrl;
using WebApi2.Services.QrCodes;

namespace WebApi2
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DataUrlService>().As<IDataUrlService>().SingleInstance();
            builder.RegisterType<QrCodeService>().As<IQrCodeService>().SingleInstance();


            var container = builder.Build();

            var dependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}