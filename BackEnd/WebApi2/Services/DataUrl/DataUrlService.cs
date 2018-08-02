using System.Collections.Generic;
using System.Linq;
using WebApi2.Models;
using WebApi2.Utils;

namespace WebApi2.Services.DataUrl
{
    public class DataUrlService : IDataUrlService
    {
        private readonly List<DataModel> _storedData;

        public DataUrlService()
        {
            var pathToXml = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/XMLDataUrl.xml");

            _storedData = Helper.ParseXml(pathToXml);
        }

        IEnumerable<DataModel> IDataUrlService.GetAll()
        {
            return _storedData.OrderBy(b => b.Id);
        }
    }
}