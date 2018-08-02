using System.Net.Http;

namespace WebApi2.Services.QrCodes
{
    public interface IQrCodeService
    {
        HttpResponseMessage GenerateQrCode(string url);
    }
}