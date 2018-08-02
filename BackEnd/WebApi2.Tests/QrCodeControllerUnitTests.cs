using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Net.Http;
using WebApi2.Controllers;
using WebApi2.Services.QrCodes;

namespace WebApi2.Tests
{
    [TestClass]
    public class QrCodeControllerUnitTests
    {
        [TestMethod]
        public void Get_ShouldReturnProperHttpResponse()
        {
            var url = "http://github.com";

            var mockRepository = new Mock<IQrCodeService>();

            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            mockRepository
                .Setup(x => x.GenerateQrCode(url))
                .Returns(expectedResponse);

            var controller = new QrCodeController(mockRepository.Object);

            var actualResponse = controller.Get(url);

            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}
