using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi2.Controllers;
using WebApi2.Models;
using WebApi2.Services.DataUrl;

namespace WebApi2.Tests
{
    [TestClass]
    public class DataUrlControllerUnitTests
    {
        [TestMethod]
        public void Get_ShouldReturnAllDataModel()
        {
            var mockRepository = new Mock<IDataUrlService>();

            var dateEntities = new[] {
                new DataModel { Id = 1, Title="Facebook", Url="http://facebook.com"},
                new DataModel { Id = 2, Title="Google", Url="http://google.com"},
                new DataModel { Id = 3, Title="Amazaon", Url="http://amazon.com"},
                new DataModel { Id = 4, Title="Instagram", Url="http://instagram.com"},
                new DataModel { Id = 5, Title="GitHub", Url="http://github.com"},
            };

            mockRepository
                .Setup(x => x.GetAll())
                .Returns(dateEntities);

            var controller = new DataUrlController(mockRepository.Object);

            var response = controller.Get();

            Assert.AreEqual(dateEntities, response);
        }
    }
}
