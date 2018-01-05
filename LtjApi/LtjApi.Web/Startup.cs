using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;

namespace LtjApi.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(Web.Filters.ComumFilter));

            });

            services.AddRouting();
            services.Configure<IISOptions>(options => {
                options.AutomaticAuthentication = true;

            });
            services.AddCors(setup => {

                setup.AddPolicy(setup.DefaultPolicyName, (builder) =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build();
                });

            });
            services.AddLogging(config =>
            {
                config.AddConsole(i => i.IncludeScopes = true);
                config.AddDebug();
                config.AddEventSourceLogger();

            });
            Dominio.Startup.ConfigureServices(services);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromSeconds(1),
                        NoCache = true
                    };
                }
            });
            Dominio.Startup.Configure(Configuration);
        }
    }
}