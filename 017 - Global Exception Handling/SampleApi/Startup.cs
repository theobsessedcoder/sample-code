using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using ObsessedCoder.GlobalExceptionMiddleware.DependencyInjection.Bootstrappers;
using SampleApi.SampleExceptions;

namespace SampleApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Map a SomethingNotFoundException to a 404 status code:
            var responseCodesByExceptionType = new Dictionary<Type, HttpStatusCode>()
            {
                [typeof(SomethingNotFoundException)] = HttpStatusCode.NotFound
            };
            services.AddGlobalExceptionMiddleware(responseCodesByExceptionType);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Register the global exception middleware with the middleware pipeline:
            app.UseGlobalExceptionMiddleware();

            if (!env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
