using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace WebApi2.Exceptions
{
    public class ApiExceptionHandler : ExceptionHandler
    {
        private class ErrorInformation
        {
            public string Message { get; set; }
            public DateTime ErrorDate { get; set; }
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new ErrorInformation
                {
                    Message = "An unexpected error occured. Please try again later.",
                    ErrorDate = DateTime.UtcNow
                }));
        }
    }
}