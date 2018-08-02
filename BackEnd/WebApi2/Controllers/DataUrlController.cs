using System.Collections.Generic;
using System.Web.Http;
using WebApi2.Filters;
using WebApi2.Models;
using WebApi2.Services.DataUrl;

namespace WebApi2.Controllers
{
    [Logging]
    public class DataUrlController : ApiController
    {
        private readonly IDataUrlService _dataModel;

        public DataUrlController(IDataUrlService dataModel)
        {
            _dataModel = dataModel;
        }

        // GET: api/DataUrl
        public IEnumerable<DataModel> Get()
        {
            return _dataModel.GetAll();
        }
    }
}
