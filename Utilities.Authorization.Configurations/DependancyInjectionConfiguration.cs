using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Authorization.Common.Models;
using Utilities.Authorization.Core.DataAccess;
using Utilities.Authorization.Core.Repositories;
using Utilities.Authorization.DataAccess;
using Utilities.Authorization.Handlers;
using Utilities.Authorization.Repositories;
using Utilities.Authorization.Services;
using IAuthorizationService = Utilities.Authorization.Core.Services.IAuthorizationService;

namespace Utilities.Authorization.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        /// <summary>
        /// Register Dependencies
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection RegisterAuthorizationDependencies(this IServiceCollection services)
        {
            #region Other - Dependancies

            // To get authentication token info
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Common Request Info Model
            services.AddScoped<RequestInformation>();


            services.AddScoped<IAuthorizationHandler, ActionPermissionHandler>();

            #endregion

            #region Repository - Dependencies

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationUserTokenRepository, ApplicationUserTokenRepository>();

            #endregion

            #region UnitOfWork - Dependencies

            services.AddScoped<IAuthorizationUnitOfWork, AuthorizationUnitOfWork>();

            #endregion

            #region Service - Dependencies

            services.AddScoped<IAuthorizationService, AuthorizationService>();

            #endregion

            return services;
        }
    }
}
