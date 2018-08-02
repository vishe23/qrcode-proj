using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApi2.Utils;

namespace WebApi2.Services.QrCodes
{
    public class QrCodeService : IQrCodeService
    {
        public HttpResponseMessage GenerateQrCode(string url)
        {
            HttpResponseMessage responseMessage;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(WebConfigHelper.GetQrCodeGeneratorApiConfig() + url);

                request.Proxy = WebConfigHelper.GetWebProxy();

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var byteImage = GetByteImage(response);
                    var memoryStream = new MemoryStream(byteImage);

                    responseMessage = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(memoryStream) };
                    responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                }
                else
                {
                    responseMessage = new HttpResponseMessage(response.StatusCode) { Content = new StringContent(response.StatusDescription) };
                }
            }
            catch (WebException e)
            {
                var statusCode = ((HttpWebResponse)e.Response)?.StatusCode ?? HttpStatusCode.NotFound;

                responseMessage = new HttpResponseMessage(statusCode) { Content = new StringContent(e.Message) };
            }

            return responseMessage;
        }

        private byte[] GetByteImage(HttpWebResponse response)
        {
            var remoteStream = response.GetResponseStream();
            var img = Image.FromStream(remoteStream);

            byte[] byteImage;
            using (var memoryStreams = new MemoryStream())
            {
                img.Save(memoryStreams, ImageFormat.Png);
                byteImage = memoryStreams.ToArray();
            }
            return byteImage;
        }
    }
}