using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ObsessedCoder.GlobalExceptionMiddleware.DependencyInjection.Models;

namespace ObsessedCoder.GlobalExceptionMiddleware.DependencyInjection.Bootstrappers
{
    public static class GlobalExceptionMiddlewareBootstrapper
    {
        public static IServiceCollection AddGlobalExceptionMiddleware(
            this IServiceCollection services,
            Dictionary<Type, HttpStatusCode> responseCodesByExceptionType = null)
        {
            services.AddTransient<GlobalExceptionMiddleware>();
            var globalExceptionMiddlewareConfiguration = new GlobalExceptionMiddlewareConfiguration()
            {
                ResponseCodesByExceptionType = responseCodesByExceptionType
            };

            services.AddTransient<GlobalExceptionMiddlewareConfiguration>(context => globalExceptionMiddlewareConfiguration);

            return services;
        }

        public static IApplicationBuilder UseGlobalExceptionMiddleware(
            this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
