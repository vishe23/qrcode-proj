﻿using System;
using System.Net;

namespace WebApi2.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode statusCode, string errorCode, string errorDescription)
            : base($"{errorCode}::{errorDescription}")
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}