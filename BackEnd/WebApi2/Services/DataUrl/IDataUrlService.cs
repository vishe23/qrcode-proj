using System.Collections.Generic;
using WebApi2.Models;

namespace WebApi2.Services.DataUrl
{
    public interface IDataUrlService
    {
        IEnumerable<DataModel> GetAll();
    }
}