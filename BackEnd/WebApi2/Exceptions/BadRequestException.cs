using System.Net;

namespace WebApi2.Exceptions
{
    public class BadRequestException : ApiException
    {
        public BadRequestException()
            : base(HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message)
            : base(HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), message)
        {
        }
    }
}