using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Modules.Main.Common.Configurations
{
    /// <summary>
    /// Swagger Configuration - Extenstion
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Swagger Configure Services - Extenstion Method
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="xmlCommentsFilePath">XML comments file path</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection SwaggerConfigureServices(this IServiceCollection services, string xmlCommentsFilePath = null)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Swashbuckle.AspNetCore.Swagger.Info()
                    {
                        Title = "Public Transport Ticketing Network Main Module APIs",
                        Version = "v1",
                        Description = "This is the documentation for Public Transport Ticketing Network - Main Module",
                        TermsOfService = "None",
                        Contact = new Swashbuckle.AspNetCore.Swagger.Contact()
                        {
                            Name = "Chathuranga Basnayake",
                            Email = "chathurangabasnayake@outlook.com"
                        }
                    });

                Dictionary<string, IEnumerable<string>> security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new Swashbuckle.AspNetCore.Swagger.ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);

                if (!string.IsNullOrEmpty(xmlCommentsFilePath))
                {
                    string filePath = System.IO.Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, xmlCommentsFilePath);
                    c.IncludeXmlComments(filePath);
                }
            });

            return services;
        }

        /// <summary>
        /// Swagger Configure - Extenstion Method
        /// </summary>
        /// <param name="app">Application Builder</param>
        /// <returns>Application Builder</returns>
        public static IApplicationBuilder UseSwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
