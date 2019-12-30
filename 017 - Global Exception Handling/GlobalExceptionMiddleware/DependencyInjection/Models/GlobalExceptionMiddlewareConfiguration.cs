using System;
using System.Collections.Generic;
using System.Net;

namespace ObsessedCoder.GlobalExceptionMiddleware.DependencyInjection.Models
{
    public class GlobalExceptionMiddlewareConfiguration
    {
        /// <summary>
        /// A mapping of exception types to http response codes
        /// </summary>
        public Dictionary<Type, HttpStatusCode> ResponseCodesByExceptionType { get; set; }
    }
}
