using System.Net.Http;
using System.Web.Http;
using WebApi2.Filters;
using WebApi2.Services.QrCodes;

namespace WebApi2.Controllers
{
    [Logging]
    public class QrCodeController : ApiController
    {
        private readonly IQrCodeService _qrCodeService;

        public QrCodeController(IQrCodeService qrCodeService)
        {
            _qrCodeService = qrCodeService;

        }

        // GET: api/QrCode?url= 
        public HttpResponseMessage Get([FromUri] string url)
        {
            return _qrCodeService.GenerateQrCode(url);
        }
    }
}
