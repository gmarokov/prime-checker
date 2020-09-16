using System;
using System.IO;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        private const string HEALTH_ENDPOINT = "/health";
        private const string SWAGGER_ENDPOINT = "api/docs";
        private const string API_NAME = "Prime Finder API Documentation";
        private const string API_DESC = "A not-so-simple example of prime finder ASP.NET Core Web API";

        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddApiVersioning()
                .AddMediatR(typeof(Startup))
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = API_NAME,
                        Description = API_DESC,
                        Contact = new OpenApiContact
                        {
                            Name = "Georgi Marokov",
                            Email = "georgi.marokov@gmail.com",
                            Url = new Uri("https://worldwildweb.dev"),
                        },
                    });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                })
                .AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection()
                .UseHealthChecks(HEALTH_ENDPOINT)
                .UseRouting()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", API_NAME);
                    c.RoutePrefix = SWAGGER_ENDPOINT;
                })
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
