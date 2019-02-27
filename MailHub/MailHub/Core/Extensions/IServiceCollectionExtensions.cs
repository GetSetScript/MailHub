using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Core.Extensions
{
    /// <summary>
    /// Represents extension methods for the <see cref="IServiceCollection"/> class
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Configures and adds the services for generating the online API Documentation
        /// </summary>
        /// <param name="services">The Services Collection to add the DI Services to</param>
        /// <param name="documentVersionName">The Version Name for the online documentation</param>
        /// <param name="documentTitle">The Title for the online documentation</param>
        /// <param name="hostingEnvironment">The <see cref="IHostingEnvironment"/> provides the fully qualified file path to the root of the application</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance</returns>
        public static IServiceCollection AddGeneratedDocumentation(this IServiceCollection services, 
                                                                   string documentVersionName, 
                                                                   string documentTitle, 
                                                                   IHostingEnvironment hostingEnvironment)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc(documentVersionName, new Info
                {
                    Title = documentTitle,
                    Version = documentVersionName
                });
                
                const string XmlCommentFileName = "MailHub.xml";
                var xmlCommentFilePath = Path.Combine(hostingEnvironment.WebRootPath, XmlCommentFileName);

                cfg.IncludeXmlComments(xmlCommentFilePath);
                cfg.DescribeAllEnumsAsStrings();
                cfg.EnableAnnotations();
            });

            return services;
        }
    }
}
