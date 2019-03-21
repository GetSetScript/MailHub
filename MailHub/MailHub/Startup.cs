using System;
using MailHub.Core.Extensions;
using MailHub.Email.Models.Configuration;
using MailHub.Email.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MailHub
{
    /// <summary>
    /// Represents the custom configuration of the Dependency Injection Services and the HTTP Pipeline
    /// </summary>
    public class Startup
    {
        private const string DocumentationTitle = "MailHub API Documentation";
        private const string DocumentationVersionNameV1 = "v1";

        private readonly string AllowedSpecificOrigins = "_allowedSpecificOrigins";

        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Creates a new <see cref="Startup"/> instance
        /// </summary>
        /// <param name="configuration">An object for retrieving the application configuration values</param>
        /// <param name="hostingEnvironment">The Hosting Environment information</param>
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the Dependency Injection Services
        /// </summary>
        /// <param name="services">The Service Collection to add the DI Services to</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGeneratedDocumentation(DocumentationVersionNameV1, DocumentationTitle, _hostingEnvironment);

            services.AddSingleton<IEmailConfiguration>(_configuration.GetSection("EmailConfiguration:SMTP").Get<EmailConfiguration>());

            services.AddTransient<ISmtpClientFactory, SmtpClientFactory>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowedSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://getsetscript.com", "http://www.getsetscript.com")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the middleware used by the HTTP Request/Response pipeline
        /// </summary>
        /// <param name="app">The Application Builder to add the middleware to</param>
        /// <param name="env">The Hosting Environment information</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseGeneratedDocumentation(DocumentationTitle, DocumentationVersionNameV1);

            app.UseCors(AllowedSpecificOrigins);
            
            app.UseMvc();
        }
    }
}
