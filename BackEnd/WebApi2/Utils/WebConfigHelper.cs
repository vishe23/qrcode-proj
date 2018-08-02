using System.Configuration;
using System.Net;

namespace WebApi2.Utils
{
    internal class WebConfigHelper
    {
        public static WebProxy GetWebProxy()
        {
            var proxy = IsProxyRequired();

            return string.IsNullOrWhiteSpace(proxy)
                         ? new WebProxy()
                                : GetProxyConfiguration(proxy);
        }

        private static WebProxy GetProxyConfiguration(string proxyUri)
        {
            return new WebProxy(proxyUri, true, new string[0],
                new NetworkCredential(GetProxyUsernameAuthentication(), GetProxyPasswordAuthentication()));
        }

        public static string GetProxyUsernameAuthentication()
        {
            return ConfigurationManager.AppSettings["ProxyAuthUsername"];
        }

        public static string GetProxyPasswordAuthentication()
        {
            return ConfigurationManager.AppSettings["ProxyAuthPassword"];
        }

        public static string IsProxyRequired()
        {
            return ConfigurationManager.AppSettings["ProxyUri"];
        }

        public static string GetQrCodeGeneratorApiConfig()
        {
            return ConfigurationManager.AppSettings["QrCodeGeneratorAPI"];
        }
    }

}