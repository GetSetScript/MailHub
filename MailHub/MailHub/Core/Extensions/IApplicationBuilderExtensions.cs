using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailHub.Core.Extensions
{
    /// <summary>
    /// Represents a collection of extension methods for the <see cref="IApplicationBuilder"/> class
    /// </summary>
    public static class IApplicationBuilderExtensions
    {
        /// <summary>
        /// Configures and adds the middleware for using the generated online API documentation
        /// </summary>
        /// <param name="app">The Application Builder to add the middleware to</param>
        /// <param name="documentTitle">The Title for the online documentation</param>
        /// <param name="documentVersionName">The Version Name for the online documentation</param>
        /// <returns>The updated <see cref="IApplicationBuilder"/> instance</returns>
        public static IApplicationBuilder UseGeneratedDocumentation(this IApplicationBuilder app, string documentTitle, string documentVersionName)
        {
            app.UseSwagger(cfg =>
            {
                cfg.RouteTemplate = "api/docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint($"/api/docs/{documentVersionName}/swagger.json", documentTitle);
                cfg.RoutePrefix = "api/docs";

                cfg.DocumentTitle = documentTitle;
                cfg.SupportedSubmitMethods();
            });

            return app;
        }

    }
}
