using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SaTRNAnalytics.Core.Interfaces;
using SaTRNAnalytics.Core.Services;
using SaTRNAnalytics.Extensions;
using SaTRNAnalytics.Infrastructure.Data;
using SaTRNAnalytics.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace SaTRNAnalytics
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;
        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          
            services.AddScoped<IGraphRepository, GraphRepository>();
            services.AddScoped<ISearchKeywordService, SearchKeywordService>();
            services.AddScoped<ISearchKeywordRepository, SearchKeywordRepository>();
            services.AddTransient(typeof(ILogger<>), (typeof(Logger<>)));
            services.Configure<ServerConfig>(Configuration.GetSection("GraphDB"));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {               
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SaTRN Analytics API",
                    Description = "Service to capture user search keywords for Analytics purpose",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Joe",
                        Email = "Joseph.E.McCormick@boeing.com"
                    },
                    License = new License
                    {
                        Name = "License Details",
                        Url = "#"
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaTRN Analytics API V1");
            });
            app.ConfigureExceptionHandler(_logger);
            app.UseMvc();
        }
    }
}
