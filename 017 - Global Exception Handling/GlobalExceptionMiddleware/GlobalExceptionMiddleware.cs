using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ObsessedCoder.GlobalExceptionMiddleware.DependencyInjection.Models;
using System.Net.Mime;
using Newtonsoft.Json;
using ObsessedCoder.GlobalExceptionMiddleware.Models;
using System.Text;

namespace ObsessedCoder.GlobalExceptionMiddleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        private readonly GlobalExceptionMiddlewareConfiguration _configuration;

        /// <summary>
        /// Creates an instance
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="configuration">The GlobalExceptionMiddlewareConfiguration</param>
        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger, GlobalExceptionMiddlewareConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception exception)
            {
                //Log this error with a unique id so we can search for it later:
                var logId = Guid.NewGuid();

                var errorResponse = new ErrorResponse(exception, logId);
                var logMessage = exception.ToString();

                using (_logger.BeginScope(
                    new Dictionary<string, object>()
                    {
                        ["LogId"] = logId
                    }))
                {
                    _logger.LogError(exception, logMessage);
                }

                context.Response.ContentType = MediaTypeNames.Application.Json;

                //Default status code for unhandled exceptions:
                context.Response.StatusCode = 500;

                if(_configuration.ResponseCodesByExceptionType != null &&
                    _configuration.ResponseCodesByExceptionType.TryGetValue(exception.GetType(), out var responseStatusCode))
                {
                    context.Response.StatusCode = (int)responseStatusCode;
                }

                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse), Encoding.UTF8);
            }
        }


    }
}
